using Room_Reservation_System.Core.DataStructure.HttpParameters;
using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Expressions
{
    /// <summary>
    /// static class containing function that return anonymous function to be used as where clause in entity
    /// </summary>
    public static class ReservationsExpressions
    {
        /// <summary>
        /// return anonymous function that check if the specified room number 
        /// and within the range of the specified time match any record
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public static Func<Reservation, bool> RoomNumberAndDate(ReservationInfo paramters)
        {
            return (entity) => { return entity.ReservedRoom?.RoomNumber == paramters.RoomNumber &&  (paramters.StartDate >= entity.Begin   &&   paramters.StartDate   <= entity.End) && (paramters.EndDate >= entity.Begin && paramters.EndDate <= entity.End); };
        }

        public static Func<Reservation, bool> RoomNumber(int roomNumber)
        {
            return (entity) => { return entity.ReservedRoom?.RoomNumber == roomNumber; };
        }

        public static Func<Reservation, bool> DateRange(DateTime startDate, DateTime endDate)
        {
            return (entity) => { return  (startDate >= entity.Begin && startDate <= entity.End) && (endDate >= entity.Begin && endDate <= entity.End); };
        }

  
    }
}
