using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.DbConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasIndex(p => p.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasOne(x => x.Table).WithMany().HasForeignKey(x => x.TableId);
        builder.HasOne(x => x.MenuItem).WithMany().HasForeignKey(x => x.FoodId);
    }
}