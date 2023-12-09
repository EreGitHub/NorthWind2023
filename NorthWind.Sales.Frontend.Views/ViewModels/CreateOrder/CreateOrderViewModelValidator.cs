namespace NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;

internal class CreateOrderViewModelValidator : IModelValidator<CreateOrderViewModel>
{
    readonly IModelValidator<CreateOrderDto> Validator;

    public CreateOrderViewModelValidator(IModelValidator<CreateOrderDto> validator) => Validator = validator;

    public IEnumerable<ValidationError> Errors => Validator.Errors;

    public Task<bool> Validate(CreateOrderViewModel model) => Validator.Validate((CreateOrderDto)model);
}
