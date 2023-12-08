namespace Microsoft.Extensions.DependencyInjection;
//namespace modificado Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices(this IServiceCollection services, Action<DBOptions> configureOptions)
    {
        services.AddValidators()
            .AddUseCasesServices()
            .AddRespositories(configureOptions)
            .AddPresenters();

        return services;
    }
}
