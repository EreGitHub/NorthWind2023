namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
        services.AddCustomExceptionHandler<ValidationException, ValidationExceptionHandler>();
        services.AddCustomExceptionHandler<UnitOfWorkException, UnitOfWorkExceptionHandler>();        
        services.AddCustomExceptionHandler<UnauthorizedAccessException, UnauthorizedAccessExceptionHandler>();
        //este manejador al final siempre,aunque ya estamos validando que esta vaya siempre al final
        services.AddUnhandledExceptionHandler();

        return services;
    }
}
