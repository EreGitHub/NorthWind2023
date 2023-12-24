namespace NorthWind.Membership.Backend.AspNetIdentity.DataContexts;

internal class NorthWindMembershipContextFactory : IDesignTimeDbContextFactory<NorthWindMembershipContext>
{
    //Migration
    //Add-Migration initialCreate -p NorthWind.Membership.Backend.AspNetIdentity -s NorthWind.Membership.Backend.AspNetIdentity -c NorthWindMembershipContext
    //dotnet ef migrations add initialCreate -p NorthWind.Membership.Backend.AspNetIdentity -s NorthWind.Membership.Backend.AspNetIdentity -c NorthWindMembershipContext
    //Update-Database -p NorthWind.Membership.Backend.AspNetIdentity -s NorthWind.Membership.Backend.AspNetIdentity -context NorthWindMembershipContext
    //dotnet ef database update -p NorthWind.Membership.Backend.AspNetIdentity -s NorthWind.Membership.Backend.AspNetIdentity -c NorthWindMembershipContext

    public NorthWindMembershipContext CreateDbContext(string[] args)
    {
        IOptions<MembershipOptions> DbOptions = Microsoft.Extensions.Options.Options.Create(new MembershipOptions
        {
            ConnectionString = "Data Source=.,15000;Initial Catalog=NorthWinUsersDB2023;User ID=sa;Password=Control123+;TrustServerCertificate=true"
        });

        return new NorthWindMembershipContext(DbOptions);
    }
}
