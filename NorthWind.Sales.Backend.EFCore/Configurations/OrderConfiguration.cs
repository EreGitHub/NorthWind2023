namespace NorthWind.Sales.Backend.EFCore.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(order => order.CustomerId)
            .IsRequired()
            .HasMaxLength(5)
            .IsFixedLength();

        builder.Property(order => order.ShipAddress)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(order => order.ShipCity)
            .HasMaxLength(15);

        builder.Property(order => order.ShipCountry)
            .HasMaxLength(15);

        builder.Property(order => order.ShipPostalCode)
            .HasMaxLength(10);

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(order => order.CustomerId);
        //.OnDelete(DeleteBehavior.ClientSetNull)
        //.HasConstraintName("FK_Orders_Customers");
    }
}
