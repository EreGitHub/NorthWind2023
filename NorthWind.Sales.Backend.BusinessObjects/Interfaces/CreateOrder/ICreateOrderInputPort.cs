namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

public interface ICreateOrderInputPort
{
    ValueTask Handle(CreateOrderDto orderDto);
}
