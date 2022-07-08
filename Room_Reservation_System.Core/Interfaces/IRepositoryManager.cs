using Room_Reservation_System.Core.DataStructure.HttpParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IReservationRepository _Reservation { get;  }
        IResourcesRepository _Resources { get;  }
        IRoomRepository _Room { get;  }
        public bool IsRoomReserved(RoomReservationInfo Paramters);
        bool Save();
        bool CreateReservation(RoomReservationInfo paramters);
        bool RemoveReservation(RoomReservationInfo paramters);
        object RoomReservations(int roomNumber);
    }
}
