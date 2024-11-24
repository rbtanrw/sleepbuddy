using BookHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookHotel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<HotelManager> HotelManagers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
