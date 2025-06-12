using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.DbConfigurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> tableBuilder)
    {
        tableBuilder.HasIndex(x => x.Id);
        tableBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
        tableBuilder.HasIndex(p => p.Number).IsUnique();
    }
}