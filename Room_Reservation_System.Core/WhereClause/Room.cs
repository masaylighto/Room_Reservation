using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.WhereClause
{
    public static class RoomWhereClause
    {
        /// <summary>
        /// return anonymous function that check if the specified room number exist in any of the record
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public static Func<Room, bool> RoomNumber(int roomNumber) {          
         return (entity) => { return entity.RoomNumber == roomNumber; };
        }
    }
}
