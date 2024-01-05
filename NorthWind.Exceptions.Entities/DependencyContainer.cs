namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCustomExceptionHandler<ExceptionType, HandlerType>(this IServiceCollection services)
        where ExceptionType : Exception
        where HandlerType : class, IExceptionHandler<ExceptionType>
    {
        services.TryAddOrchestractor();
        services.AddKeyedSingleton<object, HandlerType>(typeof(IExceptionHandler<>));

        return services;
    }

    public static IServiceCollection AddUnhandledExceptionHandler(this IServiceCollection services)
    {
        //registramos esto primero porque aqui estan nuestros manejadores, si queremos que nuestros manejadores se ejecuten primero
        //lo devemos registrar asi
        services.TryAddOrchestractor();
        //este lo registramos de ultimo porque este es el que se encarga de manejar las excepciones que no se han manejado
        //y este retorna un true y eso significa que si existe otro manejador no se ejecutara.
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
