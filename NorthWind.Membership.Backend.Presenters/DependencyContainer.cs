namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipPresenters(this IServiceCollection services, Action<JwtOptions> configureJwtOptions)
    {
        services.AddScoped<IUserRegistrationOutputPort, UserRegistrationPresenter>();
        services.AddScoped<IUserLoginOutputPort, UserLoginPresenter>();
        services.AddSingleton<JwtService>();
        services.AddOptions<JwtOptions>()
            .Configure(configureJwtOptions);

        return services;
    }
}
