namespace NorthWind.Sales.Backend.EFCore.Repositories;

internal class CommandsRepository : ICommandsRepository
{
    readonly NorthWindSalesContext Context;

    public CommandsRepository(NorthWindSalesContext context) => Context = context;

    public async ValueTask CreateOrder(OrderAggreate order)
    {
        await Context.AddAsync(order);
        await Context.AddRangeAsync(
            order.OrderDetails.Select(orderDetail => new Entities.OrderDetail
            {
                Order = order,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                UnitPrice = orderDetail.UnitPrice
            }).ToArray());
    }

    public async ValueTask SaveChanges()
    {
        await Context.SaveChangesAsync();
    }
}
