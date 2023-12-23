namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor : ICreateOrderInputPort
{
    private readonly IUserService userService;
    private readonly IDomainLogger domainLogger;
    private readonly ICommandsRepository repository;
    private readonly ICreateOrderOutputPort outputPort;
    private readonly IDomainTransaction domainTransaction;
    private readonly IEnumerable<IModelValidator<CreateOrderDto>> validators;
    private readonly IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub;

    public CreateOrderInteractor(
    IUserService userService,
    IDomainLogger domainLogger,
    ICommandsRepository repository,
    ICreateOrderOutputPort outputPort,
    IDomainTransaction domainTransaction,
    IEnumerable<IModelValidator<CreateOrderDto>> validators,
    IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub)
    {
        this.userService = userService;
        this.domainLogger = domainLogger;
        this.repository = repository;
        this.outputPort = outputPort;
        this.domainTransaction = domainTransaction;
        this.validators = validators;
        this.domainEventHub = domainEventHub;
    }
    public async ValueTask Handle(CreateOrderDto orderDto)
    {
        if (!userService.IsAuthenticated)
            throw new UnauthorizedAccessException();

        //using var Enumerator = Validators.GetEnumerator();
        var Enumerator = validators.GetEnumerator();
        bool IsValid = true;

        while (IsValid && Enumerator.MoveNext())
            IsValid = await Enumerator.Current.Validate(orderDto);

        if (!IsValid)
            throw new ValidationException(Enumerator.Current.Errors);

        await domainLogger.LogInformation(new DomainLog(
             CreateOrderMessages.StartingPurchaseOrderCreation,
             userService.UserName));

        OrderAggregate Order = OrderAggregate.From(orderDto);

        try
        {
            //domainTransaction.BeginTransaction();

            await repository.CreateOrder(Order);
            await repository.SaveChanges();

            await domainLogger.LogInformation(
                 new DomainLog(string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, Order.Id),
                 userService.UserName));

            await outputPort.Handle(Order);

            if (new SpecialOrderSpecification().IsSatisfiedBy(Order))
                await domainEventHub.Raise(
                    new SpecialOrderCreatedEvent(Order.Id, Order.OrderDetails.Count));

            //domainTransaction.CommitTransaction();
        }
        catch
        {
            //domainTransaction.RollbackTransaction();

            string Information = string.Format(CreateOrderMessages.OrderCreationCancelledTemplate, Order.Id);

            await domainLogger.LogInformation(new DomainLog(Information, userService.UserName));
            throw;
        }
    }
}
