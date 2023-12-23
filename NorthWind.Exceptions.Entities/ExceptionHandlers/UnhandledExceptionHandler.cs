namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class UnhandledExceptionHandler : IExceptionHandler
{
    readonly ILogger<UnhandledExceptionHandler> Logger;

    public UnhandledExceptionHandler(ILogger<UnhandledExceptionHandler> logger) => Logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ProblemDetails Details = new ProblemDetails();

        Details.Status = StatusCodes.Status500InternalServerError;
        Details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        Details.Title = ExceptionMessages.UnhandledExceptionTitle;
        Details.Detail = ExceptionMessages.UnhandledExceptionDetails;
        Details.Instance = $"{nameof(ProblemDetails)}/{exception.GetType()}";

        Logger.LogError(exception, ExceptionMessages.UnhandledExceptionTitle);

        await httpContext.WriteProblemDetails(Details);

        return true;
    }
}
