namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMailServices(this IServiceCollection services, Action<SmtpOptions> smtpOptions)
    {
        services.AddSingleton<IMailService, MailService>();
        services.AddOptions<SmtpOptions>().Configure(smtpOptions);

        return services;
    }
}
