namespace NorthWind.Membership.Backend.BusinessObject.Interfaces.UserRegistration;

public interface IUserRegistrationOutputPort
{
    IResult Resul { get; }

    Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult);
}
