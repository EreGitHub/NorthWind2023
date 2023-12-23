namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Authentication;

public interface IUserService
{
    bool IsAuthenticated { get; }
    string UserName { get; }
    string FullName { get; }
}
