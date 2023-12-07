namespace NorthWind.Sales.Backend.EFCore.Configurations;

internal class OrderDetailConfiguration : IEntityTypeConfiguration<Entities.OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(orderDetail => new { orderDetail.OrderId, orderDetail.ProductId });

        builder.Property(orderDetail => orderDetail.UnitPrice)
            .HasPrecision(8, 4);
    }
}
