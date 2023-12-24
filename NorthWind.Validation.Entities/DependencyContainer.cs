namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddDefaultModelValidatorService(this IServiceCollection services)
    {
        services.TryAddScoped(typeof(IModelValidatorService<>), typeof(ModelValidatorService<>));

        return services;
    }
}
