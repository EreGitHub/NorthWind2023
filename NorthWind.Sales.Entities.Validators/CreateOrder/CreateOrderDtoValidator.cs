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
            .WithMessage(CreateOrderMessages.ShipAddressMaximunLength);

        RuleFor(order => order.ShipCity)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCityRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCityMinimunLength)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCityMaximunLength);

        RuleFor(order => order.ShipCountry)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCountryRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCountryMinimumLength)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCountryMaximunLength);

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
