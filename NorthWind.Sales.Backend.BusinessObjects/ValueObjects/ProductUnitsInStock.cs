namespace NorthWind.Sales.Backend.BusinessObjects.ValueObjects;

public class ProductUnitsInStock
{
    public int ProductId { get; set; }
    public short UnitsInStock { get; set; }

    public ProductUnitsInStock(int productId, short unitsInStock)
    {
        ProductId = productId;
        UnitsInStock = unitsInStock;
    }
}
