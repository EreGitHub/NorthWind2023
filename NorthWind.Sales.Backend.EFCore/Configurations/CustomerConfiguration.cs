namespace NorthWind.Sales.Backend.EFCore.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(customer => customer.Id)
            .HasMaxLength(5)
            .IsFixedLength();

        builder.Property(customer => customer.Name)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(customer => customer.CurrentBalance)
            .HasPrecision(8, 2);

        builder.HasData(
            new Customer
            {
                Id = "ALFKI",
                Name = "Alfreds Futterkistre",
                CurrentBalance = 0
            },
            new Customer
            {
                Id = "ANATR",
                Name = "Ana Trujillo",
                CurrentBalance = 0
            },
            new Customer
            {
                Id = "ANTON",
                Name = "Antonio Moreno",
                CurrentBalance = 100
            });
    }
}
