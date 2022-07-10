using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Room_Reservation_System.Core.Interfaces
{
    public interface IResourcesRepository
    {
        /// <summary>
        /// add new resource to database
        /// </summary>
        /// <param name="resource"></param>
        void Add(Resource resource);
    }
}
