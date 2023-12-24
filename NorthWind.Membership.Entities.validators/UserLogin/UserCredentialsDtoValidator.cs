namespace NorthWind.Membership.Entities.validators.UserLogin;

internal class UserCredentialsDtoValidator : ValidatorBase<UserCredentialsDto>
{
    public UserCredentialsDtoValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(UserLoginMessages.RequiredEmailErrorMessage)
            .EmailAddress()
            .WithMessage(UserLoginMessages.InvalidEmailErrorMessage);

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage(UserLoginMessages.RequiredPasswordErrorMessage);
    }
}
