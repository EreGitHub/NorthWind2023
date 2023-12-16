namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

public interface ICreateOrderOutputPort
{
    int OrderId { get; }
    ValueTask Handle(OrderAggregate addedOrder);
}
