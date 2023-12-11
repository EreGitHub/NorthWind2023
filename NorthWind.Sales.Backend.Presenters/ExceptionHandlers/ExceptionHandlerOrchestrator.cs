namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers;

internal class ExceptionHandlerOrchestrator
{
    readonly Dictionary<Type, object> Handlers;
    readonly ILogger<ExceptionHandlerOrchestrator> Logger;

    public ExceptionHandlerOrchestrator(
        [FromKeyedServices(typeof(IExceptionHandler<>))] IEnumerable<object> handlers,
        ILogger<ExceptionHandlerOrchestrator> logger)
    {
        Handlers = new();

        foreach (var Handler in handlers)
        {
            Type ExceptionType = Handler.GetType()
                .GetInterfaces().First(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>))
                .GetGenericArguments()[0];

            Handlers.TryAdd(ExceptionType, Handler);
        }

        Logger = logger;
    }

    ProblemDetails ToProblemDeatils(Exception exception)
    {
        ProblemDetails Details;

        if (Handlers.TryGetValue(exception.GetType(), out object Handler))
        {
            Type HandlerType = Handler.GetType();

            var details = (ProblemDetails)HandlerType
                 .GetMethod(nameof(IExceptionHandler<Exception>.Handle))
                 .Invoke(Handler, new object[] { exception });

            Details = details;
        }
        else
        {
            Details = new ProblemDetails();

            Details.Status = StatusCodes.Status500InternalServerError;
            Details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
            Details.Title = ExceptionMessages.UnhandledExceptionTitle;
            Details.Detail = ExceptionMessages.UnhandledExceptionDetail;
            Details.Instance = $"{nameof(ProblemDetails)}/{exception.GetType()}";

            Logger.LogError(exception, ExceptionMessages.UnhandledExceptionTitle);
        }

        return Details;
    }

    public async Task HandleException(HttpContext context)
    {
        IExceptionHandlerFeature ExceptionDetail = context.Features.Get<IExceptionHandlerFeature>();
        Exception Exception = ExceptionDetail.Error;

        if (Exception != null)
        {
            var ProblemDetails = ToProblemDeatils(Exception);
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = ProblemDetails.Status.Value;

            var Stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(Stream, ProblemDetails);
        }
    }
}
