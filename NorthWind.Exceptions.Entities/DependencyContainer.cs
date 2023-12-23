namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCustomExceptionHandler<ExcetionType, HandlerType>(this IServiceCollection services)
        where ExcetionType : Exception
        where HandlerType : class, IExceptionHandler<ExcetionType>
    {
        services.TryAddOrchestractor();
        services.AddKeyedSingleton<object, HandlerType>(typeof(IExceptionHandler<>));

        return services;
    }

    public static IServiceCollection AddUnhandledExceptionHandler(this IServiceCollection services)
    {
        services.TryAddOrchestractor();
        services.AddExceptionHandler<UnhandledExceptionHandler>();

        return services;
    }

    static bool AddOrchestrator = true;
    static IServiceCollection TryAddOrchestractor(this IServiceCollection services)
    {
        if (AddOrchestrator)
        {
            services.AddExceptionHandler<ExceptionHandlerOrchestrator>();
            AddOrchestrator = false;
        }

        return services;
    }
}
