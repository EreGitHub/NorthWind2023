namespace NorthWind.sales.Entities.Dtos;

public class CreateOrderDto
{
    public string CustomerId { get; }
    public string ShipAddress { get; }
    public string ShipCity { get; }
    public string ShipCountry { get; }
    public string ShipPostalCode { get; }
    public List<CreateOrderDetailDto> OrderDetails { get; }

    public CreateOrderDto(string customerId, string shipAddress, string shipCity, string shipCountry, string shipPostalCode, List<CreateOrderDetailDto> orderDetails)
    {
        CustomerId = customerId;
        ShipAddress = shipAddress;
        ShipCity = shipCity;
        ShipCountry = shipCountry;
        ShipPostalCode = shipPostalCode;
        OrderDetails = orderDetails;
    }
}
