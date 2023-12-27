namespace Microsoft.AspNetCore.Builder;

public static class CreateOrderController
{
    public static WebApplication UseCreateOrderController(this WebApplication app)
    {
        //de manera predeterminada el MapPost nos devuelve un ok anose que le digamos lo contrario
        app.MapPost(Endpoints.CreateOrder, CreateOrder)
            .RequireAuthorization();

        //app.MapPost(Endpoints.CreateOrder,
        //    async (CreateOrderDto orderDto, ICreateOrderInputPort inputPort, ICreateOrderOutputPort presenter) =>
        //        Results.Ok(await CreateOrder(orderDto, inputPort, presenter))));

        return app;
    }

    //static async Task<IResult> CreateOrder(CreateOrderDto orderDto, ICreateOrderInputPort inputPort, ICreateOrderOutputPort presenter)
    //{
    //    await inputPort.Handle(orderDto);
    //    return Results.Ok(presenter.OrderId);
    //}

    public static async Task<int> CreateOrder(CreateOrderDto orderDto, ICreateOrderInputPort inputPort, ICreateOrderOutputPort presenter)
    {
        await inputPort.Handle(orderDto);
        return presenter.OrderId;
    }
}
