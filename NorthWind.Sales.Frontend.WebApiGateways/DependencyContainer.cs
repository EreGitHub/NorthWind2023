namespace Microsoft.Extensions.DependencyInjection;
//namespace modificado Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGateways(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.TryAddTransient<ExceptionDelegatingHandler>();
        services.AddHttpClient<ICreateOrderGateway, CreateOrderGateway>(configureClient)
            .AddHttpMessageHandler<ExceptionDelegatingHandler>();

        return services;
    }
}
