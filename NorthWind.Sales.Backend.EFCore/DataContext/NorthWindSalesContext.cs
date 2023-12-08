namespace NorthWind.Sales.Backend.EFCore.DataContext;

internal class NorthWindSalesContext : DbContext
{
    readonly IOptions<DBOptions> DBOptions;

    public NorthWindSalesContext(IOptions<DBOptions> dBOptions) => DBOptions = dBOptions;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Migration
        //add-Migration initialCreate -p NorthWind.Sales.Backend.EFCore -s NorthWind.Sales.Backend.EFCore -c NorthWindContext
        //Update-Database -p NorthWind.Sales.Backend.EFCore -s NorthWind.Sales.Backend.EFCore -context NorthWindContext
        optionsBuilder.UseSqlServer(DBOptions.Value.ConnectionString);
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Entities.OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
