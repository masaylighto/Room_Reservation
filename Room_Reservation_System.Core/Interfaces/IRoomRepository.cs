using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.Core.Entites;
namespace Room_Reservation_System.Core.Interfaces
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> Get(Func<Room, bool> expression, bool trackChanges);
        bool IsRoomExisted(int roomNumber);
    }
}
