namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
        services.AddCustomExceptionHandler<ValidationException, ValidationExceptionHandler>();
        services.AddCustomExceptionHandler<UnitOfWorkException, UnitOfWorkExceptionHandler>();
        //este manejador al final siempre
        services.AddCustomExceptionHandler<UnauthorizedAccessException, UnauthorizedAccessExceptionHandler>();
        services.AddUnhandledExceptionHandler();

        return services;
    }
}
