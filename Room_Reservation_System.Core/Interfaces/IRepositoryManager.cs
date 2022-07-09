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
        public bool IsRoomReserved(ReservationInfo Paramters);
        bool Save();
        bool CreateReservation(ReservationInfo paramters);
        bool RemoveReservation(ReservationInfo paramters);
        object RoomReservations(int roomNumber);
        object Reservations(DateTime startDate, DateTime endDate);
        bool CreateRoom(RoomInfo room);
        bool RemoveRoom(RoomInfo room);
        object GetRooms();
        object GetRoom(RoomInfo room);
    }
}
