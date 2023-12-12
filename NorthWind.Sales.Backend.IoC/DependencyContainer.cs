namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices
        (this IServiceCollection services, Action<DBOptions> configureOptions, Action<SmtpOptions> configureSmtpOptions)
    {
        services.AddValidators()
            .AddBusinessObjectsServices()
            .AddUseCasesServices()
            .AddRespositories(configureOptions)!
            .AddPresenters()
            .AddMailServices(configureSmtpOptions);

        return services;
    }
}
