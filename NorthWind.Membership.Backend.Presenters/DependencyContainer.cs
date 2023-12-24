namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipPresenters(this IServiceCollection services)
    {
        services.AddScoped<IUserRegistrationOutputPort, UserRegistrationPresenter>();

        return services;
    }
}
