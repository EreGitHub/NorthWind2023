namespace NorthWind.Membership.Entities.validators.UserRegistration;

internal class UserRegistrationDtoValidator : ValidatorBase<UserRegistrationDto>
{
    public UserRegistrationDtoValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(UserRegistrationMessages.RequiredEmailErrorMessage)
            .EmailAddress()
            .WithMessage(UserRegistrationMessages.InvalidEmailErrorMessage);

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage(UserRegistrationMessages.RequiredPasswordErrorMessage)
            .MinimumLength(6)
            .WithMessage(UserRegistrationMessages.PasswordTooShortErrorMessage)
            .Must(password => password.Any(caracter => char.IsLower(caracter)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresLowerErrorMessage)
            .Must(password => password.Any(caracter => char.IsUpper(caracter)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresUpperErrorMessage)
            .Must(password => password.Any(caracter => char.IsDigit(caracter)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresDigitErrorMessage)
            .Must(password => password.Any(caracter => !char.IsAsciiLetterOrDigit(caracter)))
            .WithMessage(UserRegistrationMessages.PasswordRequiresNonAlfanumericErrorMessage);

        RuleFor(user => user.FirstName)
            .NotEmpty()
            .WithMessage(UserRegistrationMessages.RequiredFirstNameErrorMessage);

        RuleFor(user => user.LastName)
            .NotEmpty()
            .WithMessage(UserRegistrationMessages.RequiredLastNameErrorMessage);
    }
}
