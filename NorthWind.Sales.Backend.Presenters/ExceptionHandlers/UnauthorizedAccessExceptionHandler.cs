namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers;

internal class UnauthorizedAccessExceptionHandler : IExceptionHandler<UnauthorizedAccessException>
{
    public ProblemDetails Handle(UnauthorizedAccessException exception) =>
        new ProblemDetails()
        {

            Status = StatusCodes.Status401Unauthorized,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-3.1",
            Title = ExceptionMessages.UnauthorizedAccessExceptionTitle,
            Detail = ExceptionMessages.UnauthorizedAccessExceptionDetail,
            Instance = $"{nameof(ProblemDetails)}/{nameof(UnauthorizedAccessException)}"
        };
}
