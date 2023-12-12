namespace NorthWind.Sales.Backend.UseCases;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
        services.AddScoped<IModelValidator<CreateOrderDto>, CreateOrderDBValidator>();
        services.AddScoped<IDomainEventHandler<SpecialOrderCreatedEvent>, SendEmailWhenSpecialOrderCreatedEventHandler>();

        return services;
    }
}
