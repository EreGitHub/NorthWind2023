namespace NorthWind.sales.Entities.Dtos;

public class CreateOrderDetailDto
{
    public int ProductId { get; }
    public decimal UnitPrice { get; }
    public short Quantity { get; }

    public CreateOrderDetailDto(int productId, decimal unitPrice, short quantity)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}
