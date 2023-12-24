namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IModelValidator<CreateOrderDto>, CreateOrderDtoValidator>();
        services.AddDefaultModelValidatorService();

        return services;
    }
}
