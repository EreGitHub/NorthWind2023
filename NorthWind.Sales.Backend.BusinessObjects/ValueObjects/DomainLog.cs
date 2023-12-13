namespace NorthWind.Sales.Backend.BusinessObjects.ValueObjects;

public class DomainLog(string information)
{
    public DateTime DateTime { get; } = DateTime.Now;
    public string Information { get; } = information;
}
