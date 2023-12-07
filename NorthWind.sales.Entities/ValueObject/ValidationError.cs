namespace NorthWind.sales.Entities.ValueObject;

public class ValidationError
{
    public string Message { get; }
    public string PropertyName { get; }

    public ValidationError(string propertyName, string message)
    {
        Message = message;
        PropertyName = propertyName;
    }
}
