namespace NorthWind.Membership.Backend.BusinessObject.Interfaces.UserRegistration;

public interface IUserRegistrationOutputPort
{
    IResult Result { get; }

    Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult);
}
