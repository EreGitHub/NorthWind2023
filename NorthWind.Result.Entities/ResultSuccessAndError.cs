namespace NorthWind.Result.Entities;

public class Result<SuccessResultType, ErrorResultType> : Result<ErrorResultType>
{
    public SuccessResultType SuccessValue { get; private set; }

    public Result(SuccessResultType successValue) : base()
    {
        SuccessValue = successValue;
    }

    public Result(ErrorResultType errorValue) : base(errorValue) { }

    public void HandlerError(Action<SuccessResultType> whenIsSuccessAction, Action<ErrorResultType> whenHasErrorAction = null)
    {
        if (HasError)
            whenHasErrorAction(ErrorValue);
        else
            whenIsSuccessAction(SuccessValue);
    }
}
