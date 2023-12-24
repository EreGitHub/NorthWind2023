namespace NorthWind.Membership.Backend.Presenters.UserRegistration;

internal class UserRegistrationPresenter : IUserRegistrationOutputPort
{
    public IResult Resul { get; private set; }

    public Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult)
    {
        userRegistrationResult.HandlerError(errors =>
        {
            Resul = Results.Problem(
                errors.ToProblemDetails(
                    Messages.UserRegistrationErrorTitle,
                    Messages.UserRegistrationErrorDetail,
                    nameof(UserRegistrationPresenter)));
        }, () => Resul = Results.Created());

        return Task.CompletedTask;
    }
}
