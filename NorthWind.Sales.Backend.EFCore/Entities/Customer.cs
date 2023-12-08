namespace NorthWind.Sales.Backend.EFCore.Entities;

internal class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal CurrentBalance { get; set; }
}
