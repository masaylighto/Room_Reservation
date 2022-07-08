using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class ResourceRepository :  IResourcesRepository
    {
        private readonly DbSet<Resource> _Resource;
        public ResourceRepository(DbSet<Resource> resources) 
        {
            _Resource = resources;
        }
    
    }
}
