using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Model;

namespace RestaurantWeb.DataBase;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {
    }

    public DbSet<Table> Tables { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<MenuItem> MenuItems { get; set; }

    public DbSet<MenuCategory> MenuCategories { get; set; }

    public DbSet<Contact> Contacts { get; set; }
}