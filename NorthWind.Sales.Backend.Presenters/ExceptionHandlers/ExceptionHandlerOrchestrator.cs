namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers;

internal class ExceptionHandlerOrchestrator : IExceptionHandler
{
    readonly Dictionary<Type, object> Handlers;

    public ExceptionHandlerOrchestrator(
        [FromKeyedServices(typeof(IExceptionHandler<>))] IEnumerable<object> handlers)
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
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        bool Handled = false;

        if (Handlers.TryGetValue(exception.GetType(), out object Handler))
        {
            Type HandlerType = Handler.GetType();
            ProblemDetails Details = (ProblemDetails)HandlerType
                .GetMethod(nameof(IExceptionHandler<Exception>.Handle))
                .Invoke(Handler, new object[] { exception });

            await httpContext.WriteProblemDetails(Details);
            Handled = true;
        }

        return Handled;
    }
}
