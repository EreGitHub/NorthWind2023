namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

//este es un manejador universal por decirlo asi, si no hay en manejador personalozado este lo va manejar
internal class UnhandledExceptionHandler : IExceptionHandler
{
    readonly ILogger<UnhandledExceptionHandler> Logger;

    public UnhandledExceptionHandler(ILogger<UnhandledExceptionHandler> logger) => Logger = logger;

    //Handle #2, este es otro manejador de excepciones, pero este es para las excepciones que no se han manejado en el handle #1
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
        //aqui estoy retornando true por que ya se manejo la excepcion
        //en caso que exista otro manejador podriamos retornar false
        return true;
    }
}
