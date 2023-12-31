﻿namespace NorthWind.Result.Entities;
//esta clase solo reporta errores no resultados de la operacion
public class Result<ErrorResultType>
{
    public ErrorResultType ErrorValue { get; private set; }
    public bool HasError { get; private set; }

    public Result()
    {
        HasError = false;
    }

    public Result(ErrorResultType errorValue)
    {
        ErrorValue = errorValue;
        HasError = true;
    }

    public void HandlerError(Action<ErrorResultType> whenHasErrorAction, Action whenIsSuccessAction = null)
    {
        if (HasError)
            whenHasErrorAction(ErrorValue);
        else
            whenIsSuccessAction?.Invoke();
        //if (whenIsSuccessAction != null)
        //    whenIsSuccessAction();
    }
}
