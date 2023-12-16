namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Repositories;

public interface ICommandsRepository : IUnitOfWork
{
    ValueTask CreateOrder(OrderAggregate order);
}
