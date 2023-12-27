namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

//este va orquestar a los exceptions handlers, es decir, va a buscar el handler que corresponda
internal class ExceptionHandlerOrchestrator : IExceptionHandler
{
    readonly Dictionary<Type, object> Handlers;

    //nueva forma para pedir servicios
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
    //Handle #1, aqui solo vamos a manejar los que heredan de IExceptionHandler<> pero podemos hacer para maneje todas las excepciones
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        bool Handled = false;

        if (Handlers.TryGetValue(exception.GetType(), out object Handler))
        {
            Type HandlerType = Handler.GetType();
            ProblemDetails Details = (ProblemDetails)HandlerType
                //esto no hace nada "<Exception>" por que lo unico que queremos es 
                //obtener el metodo nombre "Handle" para no poner quemado la palabra.
                .GetMethod(nameof(IExceptionHandler<Exception>.Handle))
                .Invoke(Handler, new object[] { exception });

            await httpContext.WriteProblemDetails(Details);
            Handled = true;
        }

        return Handled;
    }
}
