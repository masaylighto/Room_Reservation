using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Comparers.Entity.ReservationComparer
{
    /// <summary>
    /// compare the id of rooms if one of the two room is null it will return false with
    /// </summary>
    public class CompareReservationRoomNumber : IEqualityComparer<Reservation>
    {


        public bool Equals(Reservation? x, Reservation? y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            return x.ReservedRoom.RoomNumber.Equals(y.ReservedRoom.RoomNumber);
        }

        public int GetHashCode([DisallowNull] Reservation obj)
        {
            return obj.GetHashCode();
        }

    }
}
