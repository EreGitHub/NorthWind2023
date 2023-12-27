namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddBusinessObjectsServices(this IServiceCollection services)
    {
        //asi se registra los genericos
        services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));
        services.AddScoped<IDomainLogger, DomainLogger>();
        services.AddTransient<IDomainTransaction, DomainRelationalTransaction>();
        //se deve agregar primero el IHttpContextAccessor y luego los demas servicios quse basen en el
        services.AddHttpContextAccessor();
        services.AddSingleton<IUserService, UserService>();
        //services.AddSingleton<IUserService, UserServiceFake>();

        return services;
    }
}
