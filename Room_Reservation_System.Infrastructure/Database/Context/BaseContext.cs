using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Infrastructure.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Infrastructure.Database.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ResoursesConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Resource> Resources { get; set; }
    }
}
