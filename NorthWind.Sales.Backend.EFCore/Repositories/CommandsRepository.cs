namespace NorthWind.Sales.Backend.EFCore.Repositories;

internal class CommandsRepository : ICommandsRepository
{
    readonly NorthWindSalesContext Context;

    public CommandsRepository(NorthWindSalesContext context) => Context = context;

    public async ValueTask CreateOrder(OrderAggregate order)
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
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new UnitOfWorkException(ex,
                ex.Entries.Select(entry => entry.Entity.GetType().Name));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
