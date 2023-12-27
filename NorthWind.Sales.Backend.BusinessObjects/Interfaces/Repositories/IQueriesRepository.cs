namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Repositories;

public interface IQueriesRepository
{
    /// <summary>
    /// Devuelve el saldo actual del cliente, si el cliente no existe devuelve null
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    Task<decimal?> GetCustomerCurrentBalance(string customerId);

    /// <summary>
    /// tengo que enviar una lista de Ids de los productos y me devuelve una lista de ProductUnitsInStock
    /// </summary>
    /// <param name="productIds"></param>
    /// <returns></returns>
    Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds);
}
