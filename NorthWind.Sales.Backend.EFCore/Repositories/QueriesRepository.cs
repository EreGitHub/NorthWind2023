namespace NorthWind.Sales.Backend.EFCore.Repositories;

internal class QueriesRepository : IQueriesRepository
{
    readonly NorthWindSalesContext Contex;

    public QueriesRepository(NorthWindSalesContext contex) => Contex = contex;

    public async Task<decimal?> GetCustomerCurrentBalance(string customerId)
    {
        var Result = await Contex.Customers
            .Where(customer => customer.Id == customerId)
            .Select(customer => new { customer.CurrentBalance })
            .FirstOrDefaultAsync();

        return Result?.CurrentBalance;
    }

    public async Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds) =>
        await Contex.Products
            .Where(product => productIds.Contains(product.Id))
            .Select(product => new ProductUnitsInStock(product.Id, product.UnitsInStock))
            .ToListAsync();
}
