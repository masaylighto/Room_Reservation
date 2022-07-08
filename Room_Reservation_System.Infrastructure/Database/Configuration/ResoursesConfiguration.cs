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
    public class ResoursesConfiguration : IEntityTypeConfiguration<Resource>
    {
        void IEntityTypeConfiguration<Resource>.Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasData(InitialData());
        }
        Resource[] InitialData() 
        {
            List<Resource> roomResources = new ();
            roomResources.Add(new () 
            {
                Id = new Guid("6b10d231-a14e-42ae-89ce-d0e9308af831"),
                Name="Tv",
                Counts =10,
                Type =Core.Enums.RoomResourceType.ImMovable,
                RoomId = new Guid("792ba6aa-1416-482a-8f40-2557eb6a6368")

            });
            roomResources.Add(new ()
            {
                Id = new Guid("62fa0598-a9bc-4840-ac26-8c45b25fabb0"),
                Name = "Chairs",
                Counts = 50,
                Type = Core.Enums.RoomResourceType.Moveable,
                RoomId= new Guid("1faa2016-8d9d-4493-a7ce-4b2c9b0695b3")
            });
            roomResources.Add(new ()
            {
                Id = new Guid("152b0678-a3d4-4813-a30e-6ff1883519ed"),
                Name = "Table",
                Counts = 50,
                Type = Core.Enums.RoomResourceType.Moveable,
                RoomId= new Guid("0022b957-3413-4f87-9a03-7a7a4505ac9f")

            });
            return roomResources.ToArray();
        }
    }
}
