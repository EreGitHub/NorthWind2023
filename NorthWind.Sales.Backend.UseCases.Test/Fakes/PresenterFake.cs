namespace NorthWind.Sales.Backend.UseCases.Test.Fakes;

internal class PresenterFake : ICreateOrderOutputPort
{
    public int OrderId { get; private set; }

    public OrderAggreate Order { get; set; }

    public ValueTask Handle(OrderAggreate addedOrder)
    {
        Order = addedOrder;
        OrderId = addedOrder.Id;
        return ValueTask.CompletedTask;
    }
}
