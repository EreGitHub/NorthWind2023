namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

//es interna por solo se usara en este proyecto
internal class CreateOrderInteractor : ICreateOrderInputPort
{
    readonly ICreateOrderOutputPort OutputPort;
    readonly ICommandsRepository Repository;
    readonly IModelValidator<CreateOrderDto> Validator;

    public CreateOrderInteractor(ICreateOrderOutputPort outputPort, ICommandsRepository repository, IModelValidator<CreateOrderDto> validator)
    {
        OutputPort = outputPort;
        Repository = repository;
        Validator = validator;
    }

    public async ValueTask Handle(CreateOrderDto orderDto)
    {
        if (!await Validator.Validate(orderDto))
        {
            string Errors = string.Join(" ", Validator.Errors
                .Select(error => $"{error.PropertyName}: {error.Message}"));

            throw new Exception(Errors);
        }

        OrderAggreate Order = OrderAggreate.From(orderDto);

        await Repository.CreateOrder(Order);
        await Repository.SaveChanges();
        await OutputPort.Handle(Order);
    }
}
