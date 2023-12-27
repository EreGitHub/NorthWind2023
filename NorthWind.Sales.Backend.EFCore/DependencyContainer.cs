namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddRespositories(this IServiceCollection services, Action<DBOptions> configuraDbOptions)
    {
        services.Configure(configuraDbOptions);
        services.AddDbContext<NorthWindSalesContext>(); //lo registra como scope
        //lo registramos como scope por que el commadRepository utiliza el context y este esta registrado como scope
        services.AddScoped<ICommandsRepository, CommandsRepository>();
        services.AddScoped<IQueriesRepository, QueriesRepository>();
        services.AddDbContext<NorthWindDomainLogsContext>();
        services.AddScoped<IDomainLogsRepository, DomainLogsRepository>();

        return services;
    }
}
