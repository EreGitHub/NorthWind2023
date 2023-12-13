namespace NorthWind.Sales.Backend.EFCore.Entities;

internal class DomainLog
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Information { get; set; }
}
