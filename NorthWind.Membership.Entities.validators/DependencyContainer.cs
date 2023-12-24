namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipValidators(this IServiceCollection services)
    {
        services.AddScoped<IModelValidator<UserRegistrationDto>, UserRegistrationDtoValidator>();
        services.AddDefaultModelValidatorService();
        services.AddScoped<IModelValidator<UserCredentialsDto>, UserCredentialsDtoValidator>();

        return services;
    }
}
