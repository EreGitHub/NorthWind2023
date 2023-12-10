namespace NorthWind.Sales.Backend.BusinessObjects.ValueObjects;

public class ProductUnitsInStock
{
    public int ProductId { get; }
    public short UnitsInStock { get; }

    public ProductUnitsInStock(int productId, short unitsInStock)
    {
        ProductId = productId;
        UnitsInStock = unitsInStock;
    }
}
