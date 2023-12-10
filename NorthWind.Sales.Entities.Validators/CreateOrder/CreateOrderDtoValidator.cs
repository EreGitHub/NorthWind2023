namespace NorthWind.Sales.Entities.Validators.CreateOrder;

internal class CreateOrderDtoValidator : ValidatorBase<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(order => order.CustomerId)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.CustomerIdRequired)
            .Length(5)
            .WithMessage(CreateOrderMessages.CustomerIdRequiredLength);

        RuleFor(order => order.ShipAddress)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipAddressRequired)
            .MaximumLength(60)
            .WithMessage(CreateOrderMessages.ShipAddressMaximumLength);

        RuleFor(order => order.ShipCity)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCityRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCityMinimumLength)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCityMaximumLength);

        RuleFor(order => order.ShipCountry)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCountryRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCountryMinimumLength)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCountryMaximumLength);

        RuleFor(order => order.ShipPostalCode)
            .MaximumLength(10)
            .WithMessage(CreateOrderMessages.ShipPostalCodeMaximumLength);

        RuleFor(order => order.OrderDetails)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(CreateOrderMessages.OrderDetailsRequired)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.OrderDetailsNotEmpty);

        RuleForEach(order => order.OrderDetails)
            .SetValidator(new CreateOrderDetailDtoValidator());
    }
}
