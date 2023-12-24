namespace NorthWind.Membership.Backend.Presenters.UserRegistration;

internal class UserRegistrationPresenter : IUserRegistrationOutputPort
{
    public IResult Result { get; private set; }

    public Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult)
    {
        userRegistrationResult.HandlerError(errors =>
        {
            Result = Results.Problem(
                errors.ToProblemDetails(
                    Messages.UserRegistrationErrorTitle,
                    Messages.UserRegistrationErrorDetail,
                    nameof(UserRegistrationPresenter)));
        }, () => Result = Results.Created());

        return Task.CompletedTask;
    }
}
