namespace NorthWind.Sales.Backend.BusinessObjects.Services;

internal class UserServiceFake : IUserService
{
    public bool IsAuthenticate => true;

    public string UserName => "User@nothwind.com";

    public string FullName => "Usuario de prueba";
}