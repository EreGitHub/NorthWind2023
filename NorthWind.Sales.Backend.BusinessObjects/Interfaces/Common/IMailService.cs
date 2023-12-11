namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;

public interface IMailService
{
    ValueTask SendEmailToAdministrator(string subject, string body);
}
