namespace NorthWind.Sales.Backend.BusinessObjects.Services;

internal class DomainTransaction : IDomainTransaction
{
    TransactionScope TransactionScope;
    public void BeginTransaction()
    {
        TransactionManager.ImplicitDistributedTransactions = true;
        TransactionScope = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            },
            TransactionScopeAsyncFlowOption.Enabled);
    }

    public void CommitTransaction()
    {
        TransactionScope.Complete();
        Dispose();
    }

    public void Dispose()
    {
        TransactionScope?.Dispose();
    }

    public void RollbackTransaction()
    {
        Dispose();
    }
}
