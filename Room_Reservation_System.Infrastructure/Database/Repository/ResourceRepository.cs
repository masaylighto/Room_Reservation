using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.SharedKernel.Interfaces;
namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class ResourceRepository : BaseRepository<Resource>, IResourcesRepository
    {
        private DbSet<Resource> _Resource { get; set; }
        public ResourceRepository(DbSet<Resource> resources) : base(ref resources)
        {
            _Resource = resources;
        }
    }
}
