using Gimji.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gimji.Data
{
    public class MyPostgresDbContext:DbContext
    {
        public DbSet<CategoryCode> categoryCodes { get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<employee> employees{ get; set; }
        public DbSet<FoodEstablishmentReservation> reservations { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<RestaurantTable> restaurantTables { get; set; }
        public DbSet<Role> roles { get; set; }

        public MyPostgresDbContext(DbContextOptions<MyPostgresDbContext> options):base(options)
        {
        }
    }
}
