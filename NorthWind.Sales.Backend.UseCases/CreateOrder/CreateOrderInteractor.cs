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
        var Enumerator = Validators.GetEnumerator();
        bool IsValid = true;
        while (IsValid && Enumerator.MoveNext())
        {
            IsValid = await Enumerator.Current.Validate(orderDto);
            if (!IsValid)
            {
                string Errors = string.Join(" ",
                    Enumerator.Current.Errors
                        .Select(error => $"{error.PropertyName}: {error.Message}"));

                throw new Exception(Errors);
            }
        }

        OrderAggreate Order = OrderAggreate.From(orderDto);

        await Repository.CreateOrder(Order);
        await Repository.SaveChanges();
        await OutputPort.Handle(Order);
    }
}
