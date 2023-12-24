namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipService(this IServiceCollection services, Action<MembershipOptions> configureMembershipDbOptions)
    {
        services.AddDbContext<NorthWindMembershipContext>();
        services.AddIdentityCore<NorthWindUser>()
            .AddEntityFrameworkStores<NorthWindMembershipContext>();
        services.AddScoped<IMembershipService, MembershipService>();
        services.AddOptions<MembershipOptions>()
            .Configure(configureMembershipDbOptions);

        return services;
    }
}
