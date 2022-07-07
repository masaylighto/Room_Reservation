using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Comparers.Entity.RoomComparers
{
    /// <summary>
    /// compare the id of rooms if one of the two room is null it will return false with
    /// </summary>
    public class CompareRoomNumber : IEqualityComparer<Room>
    {
        public bool Equals(Room? x, Room? y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            return x.RoomNumber.Equals(y.RoomNumber);
        }

        public int GetHashCode([DisallowNull] Room obj)
        {
            return obj.GetHashCode();
        }
    }
}
