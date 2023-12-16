namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddBusinessObjectsServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));
        services.AddScoped<IDomainLogger, DomainLogger>();
        services.AddTransient<IDomainTransaction, DomainRelationalTransaction>();
        services.AddHttpContextAccessor();
        //services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IUserService, UserServiceFake>();

        return services;
    }
}
