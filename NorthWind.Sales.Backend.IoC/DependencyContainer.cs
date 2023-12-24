namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices(this IServiceCollection services, Action<DBOptions> configureOptions, Action<SmtpOptions> configureSmtpOptions, Action<MembershipOptions> configureMembershipDbOptions)
    {
        services.AddValidators()
            .AddBusinessObjectsServices()
            .AddUseCasesServices()
            .AddRespositories(configureOptions)!
            .AddPresenters()
            .AddMailServices(configureSmtpOptions)
            .AddMembershipValidators()
            .AddMembershipUseCasesServices()
            .AddMembershipPresenters()
            .AddMembershipService(configureMembershipDbOptions);


        return services;
    }
}
