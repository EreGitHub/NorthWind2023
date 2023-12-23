namespace NorthWind.Validation.Entities.Abstractions;

public abstract class ValidatorBase<T> : AbstractValidator<T>, IModelValidator<T>
{
    public IEnumerable<ValidationError> Errors { get; private set; }

    async Task<bool> IModelValidator<T>.Validate(T model)
    {
        var Result = await ValidateAsync(model);

        if (!Result.IsValid)
        {
            Errors = Result.Errors.Select(error => new ValidationError(error.PropertyName, error.ErrorMessage));
        }

        return Result.IsValid;
    }
}
