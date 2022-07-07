using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IReservationRepository Reservation { get;  }
        IResourcesRepository Resources { get;  }
        IRoomRepository Room { get;  }
        void ReserveRoom(int RoomId, DateTime StartDate, DateTime EndDate);
        void Save();
    }
}
