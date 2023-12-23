using NorthWind.Exceptions.Entities.Interfaces;

namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers;

internal class ValidationExceptionHandler : IExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception)
    {
        ProblemDetails Details = new ProblemDetails();

        Details.Status = StatusCodes.Status400BadRequest;
        Details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Details.Title = ExceptionMessages.ValidationExceptionTitle;
        Details.Detail = ExceptionMessages.ValidationExceptionDetail;
        Details.Instance = $"{nameof(ProblemDetails)}/{nameof(ValidationException)}";
        Details.Extensions.Add("errors", exception.Errors);

        return Details;
    }
}
