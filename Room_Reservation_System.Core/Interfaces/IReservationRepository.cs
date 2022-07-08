using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.Core.DataStructure.HttpParameters;

namespace Room_Reservation_System.Core.Interfaces
{
    public interface IReservationRepository
    {
        bool IsReservationExist(RoomReservationInfo paramters);
         void Add(Reservation entity);
        void Delete(Func<Reservation, bool> expression);
        IEnumerable<Reservation> Get(Func<Reservation, bool> expression,bool trackChanges);
    }
}
