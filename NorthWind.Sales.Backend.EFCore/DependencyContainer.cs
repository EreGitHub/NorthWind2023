namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddRespositories(this IServiceCollection services, Action<DBOptions> configuraDbOptions)
    {
        services.Configure(configuraDbOptions);
        services.AddDbContext<NorthWindSalesContext>();
        services.AddScoped<ICommandsRepository, CommandsRepository>();
        services.AddScoped<IQueriesRepository, QueriesRepository>();

        return services;
    }
}
