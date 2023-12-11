namespace NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;

public class CreateOrderViewModel
{
    readonly ICreateOrderGateway Gateway;

    public CreateOrderViewModel(ICreateOrderGateway gateway, IModelValidator<CreateOrderViewModel> validator) =>
        (Gateway, Validator) = (gateway, validator);

    public string CustomerId { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipPostalCode { get; set; }
    public List<CreateOrderDetailViewModel> OrderDetails { get; set; } = new();
    public IModelValidator<CreateOrderViewModel> Validator { get; set; }
    public ModelValidator<CreateOrderViewModel> ModelValidator { get; set; }
    public string InformationMessage { get; private set; }

    public void AddNewOrderDetailItem()
    {
        OrderDetails.Add(new CreateOrderDetailViewModel());
    }

    public async Task Send()
    {
        InformationMessage = string.Empty;
        try
        {
            var orderId = await Gateway.CreateOrderAsync((CreateOrderDto)this);
            InformationMessage = string.Format(CreateOrderMessages.CreateOrderTemplate, orderId);
        }
        catch (HttpRequestException ex)
        {
            if (ex.Data.Contains("Errors"))
            {
                IEnumerable<ValidationError> Errors = ex.Data["Errors"] as IEnumerable<ValidationError>;
                ModelValidator.AddErrors(Errors);
            }
            else
            {
                throw;
            }
        }
    }

    public static explicit operator CreateOrderDto(CreateOrderViewModel model) =>
        new CreateOrderDto(
            model.CustomerId,
            model.ShipAddress,
            model.ShipCity,
            model.ShipCountry,
            model.ShipPostalCode,
            model.OrderDetails
                .Select(orderDeatil =>
                    new CreateOrderDetailDto
                        (orderDeatil.ProductId, orderDeatil.UnitPrice, orderDeatil.Quantity)));
}
