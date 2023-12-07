namespace Microsoft.AspNetCore.Builder;
//namespace modificado Microsoft.AspNetCore.Builder;
public static class CreateOrderController
{
    public static WebApplication UseCreateOrderController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreateOrder, CreateOrder);

        //app.MapPost(Endpoints.CreateOrder,
        //    async (CreateOrderDto orderDto, ICreateOrderInputPort inputPort, ICreateOrderOutputPort presenter) =>
        //        Results.Ok(await CreateOrder(orderDto, inputPort, presenter))));

        return app;
    }

    static async Task<IResult> CreateOrder(CreateOrderDto orderDto, ICreateOrderInputPort inputPort, ICreateOrderOutputPort presenter)
    {
        await inputPort.Handle(orderDto);
        return Results.Ok(presenter.OrderId);
    }

    //public static async Task<int> CreateOrder(CreateOrderDto orderDto, ICreateOrderInputPort inputPort, ICreateOrderOutputPort presenter)
    //{
    //    await inputPort.Handle(orderDto);
    //    return presenter.OrderId;
    //}
}
