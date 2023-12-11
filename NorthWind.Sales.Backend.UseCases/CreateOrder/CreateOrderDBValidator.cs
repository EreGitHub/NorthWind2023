namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderDBValidator : IModelValidator<CreateOrderDto>
{
    readonly IQueriesRepository Repository;
    readonly List<ValidationError> ErrorsField = new();

    public CreateOrderDBValidator(IQueriesRepository repository) => Repository = repository;

    public IEnumerable<ValidationError> Errors => ErrorsField;

    //este metodo Validate va devolver el resultado del metodo de validacion del ValidateCustomer y del ValidateProducts
    //si ambos metodos devuelven true, entonces Validate devuelve true, si alguno de los dos devuelve false, entonces Validate devuelve false
    //si ValidateCustomer devuelve false, entonces no se ejecuta ValidateProducts y eso porque tiene doble "&&" y tuviera solo uno "&" entonces se ejecutaria ValidateProducts
    public async Task<bool> Validate(CreateOrderDto model) =>
        await ValidateCustomer(model) && await ValidateProducts(model);

    private async Task<bool> ValidateProducts(CreateOrderDto model)
    {
        IEnumerable<ProductUnitsInStock> RequiredQuantities = model
            .OrderDetails
            .GroupBy(detail => detail.ProductId)
            .Select(group => new ProductUnitsInStock(group.Key, (short)group.Sum(detail => detail.Quantity)));

        var ProductIds = RequiredQuantities.Select(product => product.ProductId);

        IEnumerable<ProductUnitsInStock> InStockQuantities = await Repository.GetProductsUnitsInStock(ProductIds);

        var RequiredVsInStock = RequiredQuantities
            .GroupJoin(InStockQuantities,
                required => required.ProductId,
                inStock => inStock.ProductId,
                (oneRequired, manyInStock) => new { oneRequired, manyInStock })
            .SelectMany(groupResult => groupResult.manyInStock.DefaultIfEmpty(),
            (groupResult, singleInStock) => new
            {
                groupResult.oneRequired.ProductId,
                Required = groupResult.oneRequired.UnitsInStock,
                InStock = singleInStock?.UnitsInStock
            });

        foreach (var Item in RequiredVsInStock)
        {
            if (!Item.InStock.HasValue)
            {
                CreateOrderDetailDto OrderDetail = model.OrderDetails.First(detail => detail.ProductId == Item.ProductId);
                var Index = model.OrderDetails.ToList().IndexOf(OrderDetail);
                string PropertyName = $"{nameof(model.OrderDetails)}[{Index}].{nameof(OrderDetail.ProductId)}";

                ErrorsField.Add(new ValidationError(
                    PropertyName,
                    string.Format(CreateOrderMessages.ProductIdNotFoundErrorTemplate, Item.ProductId)));
            }
            else if (Item.InStock < Item.Required)
            {
                CreateOrderDetailDto OrderDetail = model.OrderDetails.Last(detail => detail.ProductId == Item.ProductId);
                var Index = model.OrderDetails.ToList().IndexOf(OrderDetail);
                string PropertyName = $"{nameof(model.OrderDetails)}[{Index}].{nameof(OrderDetail.Quantity)}";

                ErrorsField.Add(new ValidationError(
                    PropertyName,
                    string.Format(
                        CreateOrderMessages.UnitsInStockLessThanQuantityErrorTemplate,
                        Item.Required, Item.InStock, Item.ProductId)));

            }
        }

        return !ErrorsField.Any();
    }

    private async Task<bool> ValidateCustomer(CreateOrderDto model)
    {
        var CurrentBalance = await Repository.GetCustomerCurrentBalance(model.CustomerId);

        if (CurrentBalance == null)
        {
            ErrorsField.Add(new ValidationError(nameof(model.CustomerId), CreateOrderMessages.CustomerIdNotFoundError));
        }
        else if (CurrentBalance > 0)
        {
            ErrorsField.Add(new ValidationError(
                nameof(model.CustomerId),
                string.Format(CreateOrderMessages.CustomerWithBalanceErrorTemplate, model.CustomerId, CurrentBalance)));
        }

        return !ErrorsField.Any();
    }
}
