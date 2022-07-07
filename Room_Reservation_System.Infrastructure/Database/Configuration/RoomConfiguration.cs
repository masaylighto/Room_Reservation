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
            List<Room> roomResources = new();
            roomResources.Add(new () { });
            roomResources.Add(new () { });
            roomResources.Add(new () { });
            return roomResources.ToArray();
        }
    }
}
