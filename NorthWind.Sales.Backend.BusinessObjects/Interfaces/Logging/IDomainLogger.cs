namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Logging;

public interface IDomainLogger
{
    ValueTask LogInformation(DomainLog log);
}
