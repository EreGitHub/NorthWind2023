namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class SpecialOrderCreatedEvent(int orderId, int productsCount) : IDomainEvent
{
    public int OrderId { get; } = orderId;
    public int ProductsCount { get; } = productsCount;
}
