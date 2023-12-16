namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Authentication;

public interface IUserService
{
    bool IsAuthenticate { get; }
    string UserName { get; }
    string FullName { get; }
}
