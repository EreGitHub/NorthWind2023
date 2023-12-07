namespace NorthWind.Sales.Backend.UseCases.Test.Fakes;

internal class RepositoryFake : ICommandsRepository
{
    OrderAggreate Order;
    public ValueTask CreateOrder(OrderAggreate order)
    {
        Order = order;
        return ValueTask.CompletedTask;
    }

    public ValueTask SaveChanges()
    {
        Order.Id = 1;
        return ValueTask.CompletedTask;
    }
}
