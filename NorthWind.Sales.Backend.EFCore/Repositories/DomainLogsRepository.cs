namespace NorthWind.Sales.Backend.EFCore.Repositories;

internal class DomainLogsRepository(NorthWindDomainLogsContext context) : IDomainLogsRepository
{
    public async ValueTask Add(BusinessObjects.ValueObjects.DomainLog log)
    {
        await context.AddAsync(new Entities.DomainLog
        {
            CreatedDate = log.DateTime,
            Information = log.Information,
        });
    }

    public async ValueTask SaveChanges()
    {
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new UnitOfWorkException(ex,
                ex.Entries.Select(entry => entry.Entity.GetType().Name));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
