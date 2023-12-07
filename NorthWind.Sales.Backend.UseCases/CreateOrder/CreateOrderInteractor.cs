namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

//es interna por solo se usara en este proyecto
internal class CreateOrderInteractor : ICreateOrderInputPort
{
    readonly ICreateOrderOutputPort OutputPort;
    readonly ICommandsRepository Repository;

    public CreateOrderInteractor(ICreateOrderOutputPort outputPort, ICommandsRepository repository)
    {
        OutputPort = outputPort;
        Repository = repository;
    }

    public async ValueTask Handle(CreateOrderDto orderDto)
    {
        OrderAggreate Order = OrderAggreate.From(orderDto);

        await Repository.CreateOrder(Order);
        await Repository.SaveChanges();
        await OutputPort.Handle(Order);
    }
}
