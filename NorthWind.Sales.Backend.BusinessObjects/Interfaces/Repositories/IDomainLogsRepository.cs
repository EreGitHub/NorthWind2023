namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Repositories;

public interface IDomainLogsRepository : IUnitOfWork
{
    ValueTask Add(DomainLog log);
}
