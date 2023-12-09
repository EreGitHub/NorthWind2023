namespace Microsoft.Extensions.DependencyInjection;
//namespace modificado Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddViewServices(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderViewModel>();
        services.AddScoped<IModelValidator<CreateOrderViewModel>, CreateOrderViewModelValidator>();

        return services;
    }
}
