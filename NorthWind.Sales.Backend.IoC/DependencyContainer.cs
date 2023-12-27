namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection
        AddNorthWindSalesServices(this IServiceCollection services, Action<DBOptions> configureOptions, Action<SmtpOptions> configureSmtpOptions,
        Action<MembershipOptions> configureMembershipDbOptions, Action<JwtOptions> configureJwtOptionss)
    {
        services.AddValidators()
            .AddBusinessObjectsServices()
            .AddUseCasesServices()
            .AddRespositories(configureOptions)!
            .AddPresenters()
            .AddMailServices(configureSmtpOptions)
            .AddMembershipValidators()
            .AddMembershipUseCasesServices()
            .AddMembershipPresenters(configureJwtOptionss)
            .AddMembershipService(configureMembershipDbOptions);

        return services;
    }
}
