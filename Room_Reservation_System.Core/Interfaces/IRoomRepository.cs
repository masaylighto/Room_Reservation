using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.Core.DataStructure.HttpParameters;
using Room_Reservation_System.Core.Entites;
namespace Room_Reservation_System.Core.Interfaces
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> Get(Func<Room, bool> expression, bool trackChanges);
        bool IsExist(int roomNumber);
        void Add(Room room);
        void Delete(Func<Room, bool> expression);

        IQueryable<Room> Get(bool trackChanges);
    }
}
