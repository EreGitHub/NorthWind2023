namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Transactions;

public interface IDomainTransaction : IDisposable
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
