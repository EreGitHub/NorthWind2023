namespace Microsoft.Extensions.DependencyInjection;
//namespace modificado Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices(this IServiceCollection services, Action<DBOptions> configureOptions)
    {
        services.AddUseCasesServices()
            .AddRespositories(configureOptions)
            .AddPresenters()
            .AddValidators();

        return services;
    }
}
