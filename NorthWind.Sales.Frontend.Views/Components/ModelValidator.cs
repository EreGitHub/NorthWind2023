﻿namespace NorthWind.Sales.Frontend.Views.Components;

public class ModelValidator<T> : ComponentBase
{
    [CascadingParameter]
    EditContext EditContext { get; set; }

    [Parameter]
    public IModelValidator<T> Validator { get; set; }

    ValidationMessageStore ValidationMessageStore { get; set; }

    FieldIdentifier GetFieldIdentifier(object model, string propertyName)
    {
        char[] PropertyNameSeparator = new char[] { '.', '[' };

        object NewModel = model;

        string PropertyPath = propertyName;
        int SeparatorIndex;
        string Token = null;
        do
        {
            SeparatorIndex = PropertyPath.LastIndexOfAny(PropertyNameSeparator);
            if (SeparatorIndex >= 0)
            {
                Token = PropertyPath.Substring(0, SeparatorIndex);
                PropertyPath = PropertyPath.Substring(SeparatorIndex + 1);

                if (Token.EndsWith("]"))
                {
                    Token = Token.Substring(0, Token.Length - 1);
                    PropertyInfo PropertyInfo = NewModel.GetType().GetProperty("Item");

                    var IndexType = PropertyInfo.GetIndexParameters()[0].ParameterType;

                    var IndexValue = Convert.ChangeType(Token, IndexType);

                    NewModel = PropertyInfo.GetValue(NewModel, new object[] { IndexValue });
                }
                else
                {
                    var PropertyInfo = NewModel.GetType().GetProperty(Token);
                    NewModel = PropertyInfo.GetValue(NewModel);
                }
                Token = null;
            }
        } while (SeparatorIndex >= 0);

        return new FieldIdentifier(NewModel, Token ?? PropertyPath);
    }

    async void ValidationRequested(object sender, ValidationRequestedEventArgs args)
    {
        ValidationMessageStore.Clear();

        bool IsValid = await Validator.Validate((T)EditContext.Model);

        if (!IsValid)
        {
            foreach (var Error in Validator.Errors)
            {
                var FieldIdentifier = GetFieldIdentifier(EditContext.Model, Error.PropertyName);
                ValidationMessageStore.Add(FieldIdentifier, Error.Message);
            }
        }

        EditContext.NotifyValidationStateChanged();
    }

    async void FieldChanged(object sender, FieldChangedEventArgs args)
    {
        ValidationMessageStore.Clear(args.FieldIdentifier);

        bool IsValid = await Validator.Validate((T)EditContext.Model);

        if (!IsValid)
        {
            foreach (var Error in Validator.Errors)
            {
                var FieldIdentifier = GetFieldIdentifier(EditContext.Model, Error.PropertyName);
                if (FieldIdentifier.FieldName == args.FieldIdentifier.FieldName && FieldIdentifier.Model == args.FieldIdentifier.Model)
                {
                    ValidationMessageStore.Add(FieldIdentifier, Error.Message);
                }
            }
        }

        EditContext.NotifyValidationStateChanged();
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        EditContext PreviousEditContext = EditContext;
        await base.SetParametersAsync(parameters);
        if (EditContext != PreviousEditContext)
        {
            ValidationMessageStore = new ValidationMessageStore(EditContext);
            EditContext.OnValidationRequested += ValidationRequested;
            EditContext.OnFieldChanged += FieldChanged;
        }
    }
}
