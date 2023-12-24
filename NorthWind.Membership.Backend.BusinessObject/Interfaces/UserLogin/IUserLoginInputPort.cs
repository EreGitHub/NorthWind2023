namespace NorthWind.Membership.Backend.BusinessObject.Interfaces.UserLogin;

public interface IUserLoginInputPort
{
    Task Handle(UserCredentialsDto userData);
}
