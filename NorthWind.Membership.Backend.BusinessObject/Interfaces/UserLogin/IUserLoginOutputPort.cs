namespace NorthWind.Membership.Backend.BusinessObject.Interfaces.UserLogin;

public interface IUserLoginOutputPort
{
    IResult Result { get; }
    Task Handle(Result<UserDto, IEnumerable<ValidationError>> userLoginResult);
}
