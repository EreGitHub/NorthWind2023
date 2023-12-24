namespace NorthWind.Validation.Entities.Services;

internal class ModelValidatorService<ModelType> : IModelValidatorService<ModelType>
{
    readonly IEnumerable<IModelValidator<ModelType>> Validators;

    public IEnumerable<ValidationError> Errors { get; private set; }
    public ModelValidatorService(IEnumerable<IModelValidator<ModelType>> validators) => Validators = validators;

    public async Task<bool> Validate(ModelType model)
    {
        using var Enumerator = Validators.GetEnumerator();
        bool IsValid = true;

        while (IsValid && Enumerator.MoveNext())
            IsValid = await Enumerator.Current.Validate(model);

        if (!IsValid)
            Errors = Enumerator.Current.Errors;

        return IsValid;
    }
}
