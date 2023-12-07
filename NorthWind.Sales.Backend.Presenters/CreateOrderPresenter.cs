namespace NorthWind.Sales.Backend.Presenters;

internal class CreateOrderPresenter : ICreateOrderOutputPort
{
    public int OrderId { get; private set; }

    public ValueTask Handle(OrderAggreate addedOrder)
    {
        OrderId = addedOrder.Id;
        return ValueTask.CompletedTask;
    }
}
