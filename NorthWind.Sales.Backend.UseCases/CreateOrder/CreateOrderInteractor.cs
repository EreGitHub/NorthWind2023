namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor(
    IDomainLogger domainLogger,
    ICommandsRepository repository,
    ICreateOrderOutputPort outputPort,
    IEnumerable<IModelValidator<CreateOrderDto>> validators,
    IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub) : ICreateOrderInputPort
{
    public async ValueTask Handle(CreateOrderDto orderDto)
    {
        //preguntar: esto se tiene que hacer en cada interactor?
        //using var Enumerator = Validators.GetEnumerator();
        var Enumerator = validators.GetEnumerator();
        bool IsValid = true;

        while (IsValid && Enumerator.MoveNext())
            IsValid = await Enumerator.Current.Validate(orderDto);

        if (!IsValid)
            throw new ValidationException(Enumerator.Current.Errors);

        await domainLogger.LogInformation(new DomainLog(
             CreateOrderMessages.StartingPurchaseOrderCreation));

        OrderAggreate Order = OrderAggreate.From(orderDto);

        await repository.CreateOrder(Order);
        await repository.SaveChanges();

        await domainLogger.LogInformation(
             new DomainLog(string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, Order.Id)));

        await outputPort.Handle(Order);

        if (Order.OrderDetails.Count > 3)
            await domainEventHub.Raise(
                new SpecialOrderCreatedEvent(Order.Id, Order.OrderDetails.Count));
    }
}
