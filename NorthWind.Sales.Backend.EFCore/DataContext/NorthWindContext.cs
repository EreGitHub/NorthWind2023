﻿namespace NorthWind.Sales.Backend.EFCore.DataContext;

//esto solo es en tiempo de diseño
internal class NorthWindContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Migration
        //add-Migration initialCreate -p NorthWind.Sales.Backend.EFCore -s NorthWind.Sales.Backend.EFCore -c NorthWindContext
        //Update-Database -p NorthWind.Sales.Backend.EFCore -s NorthWind.Sales.Backend.EFCore -context NorthWindContext
        optionsBuilder.UseSqlServer("Data Source=.,15000;Initial Catalog=NorthWinDB2023;User ID=sa;Password=Control123+;TrustServerCertificate=true");
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Entities.OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}