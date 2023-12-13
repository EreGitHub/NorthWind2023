namespace NorthWind.Sales.Backend.BusinessObjects.Services;

internal class DomainLogger(IDomainLogsRepository repository) : IDomainLogger
{
    public async ValueTask LogInformation(DomainLog log)
    {
        await repository.Add(log);
        await repository.SaveChanges();
    }
}
