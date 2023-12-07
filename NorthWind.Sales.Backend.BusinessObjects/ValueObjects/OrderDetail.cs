namespace NorthWind.Sales.Backend.BusinessObjects.ValueObjects;

public record struct OrderDetail(int ProductId, decimal UnitPrice, short Quantity);
