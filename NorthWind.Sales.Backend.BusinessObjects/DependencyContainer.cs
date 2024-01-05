namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddBusinessObjectsServices(this IServiceCollection services)
    {
        //asi se registra los genericos
        services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));
        services.AddScoped<IDomainLogger, DomainLogger>();
        //cada vez que lo necesite me va a crear una nueva instancia
        services.AddTransient<IDomainTransaction, DomainRelationalTransaction>();
        //se debe agregar primero el IHttpContextAccessor y luego los demas servicios que hacen uso de ese sercvicio
        services.AddHttpContextAccessor();
        services.AddSingleton<IUserService, UserService>();
        //services.AddSingleton<IUserService, UserServiceFake>();

        return services;
    }
}
