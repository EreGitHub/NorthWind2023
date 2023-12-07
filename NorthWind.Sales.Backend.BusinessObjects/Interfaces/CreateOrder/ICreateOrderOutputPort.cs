namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

public interface ICreateOrderOutputPort
{
    int OrderId { get; }
    ValueTask Handle(OrderAggreate addedOrder);
}
