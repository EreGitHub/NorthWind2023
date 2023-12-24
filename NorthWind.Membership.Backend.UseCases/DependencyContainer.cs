namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRegistrationInputPort, UserRegistrationInteractor>();
        //services.TryAddScoped<ModelValidatorService<UserRegistrationDto>>();

        return services;
    }
}
