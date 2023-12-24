namespace NorthWind.Membership.Backend.BusinessObject.Interfaces.UserRegistration;

public interface IUserRegistrationInputPort
{
    Task Handle(UserRegistrationDto userData);
}
