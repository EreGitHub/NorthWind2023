namespace NorthWind.Validation.Entities.Interfaces;

public interface IModelValidator<T>
{
    Task<bool> Validate(T model);
    IEnumerable<ValidationError> Errors { get; }
}
