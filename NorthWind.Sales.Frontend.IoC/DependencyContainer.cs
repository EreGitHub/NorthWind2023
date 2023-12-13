namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddWebApiGateways(configureClient)
            .AddViewServices()
            .AddValidators();

        return services;
    }
}
