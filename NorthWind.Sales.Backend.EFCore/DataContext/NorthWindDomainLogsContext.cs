namespace NorthWind.Sales.Backend.EFCore.DataContext;

internal class NorthWindDomainLogsContext(IOptions<DBOptions> dbOptions) : DbContext
{
    //Add-Migration addDomainLog -p NorthWind.Sales.Backend.EFCore -s NorthWind.Sales.Backend.EFCore -c NorthWindDomainLogsContext
    //Update-Database -p NorthWind.Sales.Backend.EFCore -s NorthWind.Sales.Backend.EFCore -context NorthWindDomainLogsContext
    public DbSet<Entities.DomainLog> DomainLogs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(dbOptions.Value.DomainLogsConnectionString);
    }
}
