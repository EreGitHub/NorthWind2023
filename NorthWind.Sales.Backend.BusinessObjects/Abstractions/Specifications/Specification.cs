namespace NorthWind.Sales.Backend.BusinessObjects.Abstractions.Specifications;

public abstract class Specification<T>
{
    //esto es para forzar al implementador para que lo implemente, para que ponga las reglas de negocio ahi.
    public abstract Expression<Func<T, bool>> ConditionExpression { get; }

    public bool IsSatisfiedBy(T entityInstance)
    {
        Func<T, bool> ExpressionDelegate = ConditionExpression.Compile();

        return ExpressionDelegate(entityInstance);
    }
}
