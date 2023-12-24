namespace NorthWind.Membership.Backend.AspNetIdentity.Services;

internal static class ErrorMessageMapper
{
    public static IEnumerable<ValidationError> ToValidationError(this IEnumerable<IdentityError> errors)
    {
        List<ValidationError> Result = [];
        foreach (var Error in errors)
        {
            switch (Error.Code)
            {
                case nameof(IdentityErrorDescriber.DuplicateUserName):
                    Result.Add(new ValidationError(
                        nameof(UserRegistrationDto.Email),
                        Messages.DuplicateUserNameErrorMessage));
                    break;
                default:
                    Result.Add(new ValidationError(Error.Code, Error.Description));
                    break;
            }
        }

        return Result;
    }
}