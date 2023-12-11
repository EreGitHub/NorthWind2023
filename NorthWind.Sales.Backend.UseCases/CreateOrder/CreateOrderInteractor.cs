namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor : ICreateOrderInputPort
{
    readonly ICreateOrderOutputPort OutputPort;
    readonly ICommandsRepository Repository;
    readonly IEnumerable<IModelValidator<CreateOrderDto>> Validators;

    public CreateOrderInteractor(ICreateOrderOutputPort outputPort, ICommandsRepository repository, IEnumerable<IModelValidator<CreateOrderDto>> validators)
    {
        OutputPort = outputPort;
        Repository = repository;
        Validators = validators;
    }

    public async ValueTask Handle(CreateOrderDto orderDto)
    {
        //preguntar: esto se tiene que hacer en cada interactor?
        //using var Enumerator = Validators.GetEnumerator();
        var Enumerator = Validators.GetEnumerator();
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

        await Repository.CreateOrder(Order);
        await Repository.SaveChanges();
        await OutputPort.Handle(Order);
    }
}
