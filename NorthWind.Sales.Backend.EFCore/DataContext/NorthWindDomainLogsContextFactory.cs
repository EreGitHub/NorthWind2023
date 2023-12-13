namespace NorthWind.Sales.Backend.EFCore.DataContext;

internal class NorthWindDomainLogsContextFactory : IDesignTimeDbContextFactory<NorthWindDomainLogsContext>
{
    public NorthWindDomainLogsContext CreateDbContext(string[] args)
    {
        IOptions<DBOptions> DbOptions = Microsoft.Extensions.Options.Options.Create(new DBOptions
        {
            DomainLogsConnectionString = "Data Source=.,15000;Initial Catalog=NorthWinLogsDB2023;User ID=sa;Password=Control123+;TrustServerCertificate=true"
        });

        return new NorthWindDomainLogsContext(DbOptions);
    }
}
