using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Infrastructure.Database.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        void IEntityTypeConfiguration<Room>.Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(InitialData());
        }
        Room[] InitialData() 
        {
            List<Room> rooms = new();
            rooms.Add(new () 
            {
                RoomNumber = 512,
                Id = new Guid("792ba6aa-1416-482a-8f40-2557eb6a6368"),
                Capacity = 50,
                Type =Core.Enums.RoomType.SettingRoom,
                Location= "Berlin",
                Reservations= new List<Reservation>(),
                Resources = new List<Resource>(),
            });
            rooms.Add(new () 
            {
                RoomNumber = 522,
                Id = new Guid("1faa2016-8d9d-4493-a7ce-4b2c9b0695b3"),
                Capacity = 50,
                Type = Core.Enums.RoomType.StandingRoom,
                Location = "Amsterdam",
                Reservations = new List<Reservation>(),
                Resources = new List<Resource>(),
            });
            rooms.Add(new () 
            {
                RoomNumber=542,
                Id= new Guid("0022b957-3413-4f87-9a03-7a7a4505ac9f"),
                Capacity =50,
                Type = Core.Enums.RoomType.StandingRoom,
                Location = "Berlin",
                Reservations = new List<Reservation>(),
                Resources = new List<Resource>(),
            });
            return rooms.ToArray();
        }
    }
}
