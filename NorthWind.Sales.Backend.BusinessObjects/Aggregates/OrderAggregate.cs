namespace NorthWind.Sales.Backend.BusinessObjects.Aggregates;

public class OrderAggregate : Order
{
    readonly List<OrderDetail> OrderDetailsField = new List<OrderDetail>();

    public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField.AsReadOnly();

    public void AddDetail(int productId, decimal unitPrice, short quantity)
    {
        var ExistingOrderDetail = OrderDetailsField.FirstOrDefault(order => order.ProductId == productId);
        if (ExistingOrderDetail != default)
        {
            quantity += ExistingOrderDetail.Quantity;
            OrderDetailsField.Remove(ExistingOrderDetail);
        }

        OrderDetailsField.Add(new(productId, unitPrice, quantity));
    }

    public static OrderAggregate From(CreateOrderDto orderDto)
    {
        OrderAggregate Order = new OrderAggregate
        {
            CustomerId = orderDto.CustomerId,
            ShipAddress = orderDto.ShipAddress,
            ShipCity = orderDto.ShipCity,
            ShipCountry = orderDto.ShipCountry,
            ShipPostalCode = orderDto.ShipPostalCode,
        };

        foreach (var Item in orderDto.OrderDetails)
        {
            Order.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
        }

        return Order;
    }
}
