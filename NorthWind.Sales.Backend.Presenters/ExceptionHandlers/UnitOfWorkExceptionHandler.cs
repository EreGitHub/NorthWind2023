using NorthWind.Exceptions.Entities.Interfaces;

namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers;

internal class UnitOfWorkExceptionHandler : IExceptionHandler<UnitOfWorkException>
{
    readonly ILogger<UnitOfWorkExceptionHandler> Logger;

    public UnitOfWorkExceptionHandler(ILogger<UnitOfWorkExceptionHandler> logger) => Logger = logger;

    public ProblemDetails Handle(UnitOfWorkException exception)
    {
        ProblemDetails Details = new();

        Details.Status = StatusCodes.Status500InternalServerError;
        Details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        Details.Title = ExceptionMessages.UnitOfWorkExceptionTitle;
        Details.Detail = ExceptionMessages.UnitOfWorkExceptionDetail;
        Details.Instance = $"{nameof(ProblemDetails)}/{nameof(UnitOfWorkException)}";

        Logger.LogError(exception, ExceptionMessages.UnitOfWorkExceptionTitle + ": " + string.Join(" ", exception.Entities));

        return Details;
    }
}
