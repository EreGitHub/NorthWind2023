namespace NorthWind.Sales.Backend.BusinessObjects.ValueObjects;

public class DomainLog(string information, string UserName)
{
    public DateTime DateTime { get; } = DateTime.Now;
    public string Information { get; } = information;
    public string UserName { get; } = UserName;
}
