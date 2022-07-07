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
            roomResources.Add(new () { });
            roomResources.Add(new () { });
            roomResources.Add(new () { });
            return roomResources.ToArray();
        }
    }
}
