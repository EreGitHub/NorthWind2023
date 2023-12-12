namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor(
    ICreateOrderOutputPort outputPort,
    ICommandsRepository repository,
    IEnumerable<IModelValidator<CreateOrderDto>> validators
    //IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub
    ) : ICreateOrderInputPort
{
    public async ValueTask Handle(CreateOrderDto orderDto)
    {
        //preguntar: esto se tiene que hacer en cada interactor?
        //using var Enumerator = Validators.GetEnumerator();
        var Enumerator = validators.GetEnumerator();
        bool IsValid = true;
        while (IsValid && Enumerator.MoveNext())
        {
            IsValid = await Enumerator.Current.Validate(orderDto);
            if (!IsValid)
            {
                throw new ValidationException(Enumerator.Current.Errors);
            }
        }

        OrderAggreate Order = OrderAggreate.From(orderDto);

        await repository.CreateOrder(Order);
        await repository.SaveChanges();
        await outputPort.Handle(Order);

        //if (Order.OrderDetails.Count > 3)
        //    await domainEventHub.Raise(
        //        new SpecialOrderCreatedEvent(Order.Id, Order.OrderDetails.Count));
    }
}
