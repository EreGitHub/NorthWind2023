namespace NorthWind.Membership.Backend.BusinessObject.Interfaces.Common;

public interface IMembershipService
{
    Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData);
    Task<UserDto> GetUserByCredentials(UserCredentialsDto userData);
}
