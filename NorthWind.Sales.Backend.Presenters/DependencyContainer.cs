namespace NorthWind.Sales.Backend.Presenters;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
        services.AddKeyedSingleton<object, ValidationExceptionHandler>(typeof(IExceptionHandler<>));
        services.AddKeyedSingleton<object, UnitOfWorkExceptionHandler>(typeof(IExceptionHandler<>));
        services.AddSingleton<ExceptionHandlerOrchestrator>();

        return services;
    }

    public static WebApplication UseCustomExceptionHandlers(this WebApplication app)
    {
        var Orchestrator = app.Services.GetRequiredService<ExceptionHandlerOrchestrator>();

        app.UseExceptionHandler(appBuilder => appBuilder.Run(Orchestrator.HandleException));

        return app;
    }
}
