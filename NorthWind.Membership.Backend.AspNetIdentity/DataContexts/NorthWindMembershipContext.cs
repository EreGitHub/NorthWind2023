namespace NorthWind.Membership.Backend.AspNetIdentity.DataContexts;

internal class NorthWindMembershipContext : IdentityDbContext<NorthWindUser>
{
    readonly MembershipOptions _dbOptions;
    public NorthWindMembershipContext(IOptions<MembershipOptions> dbOptions) => _dbOptions = dbOptions.Value;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_dbOptions.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
