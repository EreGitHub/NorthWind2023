namespace NorthWind.Sales.Entities.Validators.CreateOrder;

internal class CreateOrderDetailDtoValidator : ValidatorBase<CreateOrderDetailDto>
{
    public CreateOrderDetailDtoValidator()
    {
        RuleFor(orderDetail => orderDetail.ProductId)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.ProductIdGreatherThanZero);

        RuleFor<int>(orderDetail => orderDetail.Quantity)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.QuantityGreatherThanZero);

        RuleFor(orderDetail => orderDetail.UnitPrice)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.UnitPriceGreatherThanZero);
    }
}
