using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Expressions
{
    /// <summary>
    /// provide list of anonymous function that work as "where lambada" 
    /// </summary>
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


    public static class RoomSelectClause
    {
        /// <summary>
        /// return anonymous function that check if the specified room number exist in any of the record
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public static Func<Room, object> Info()
        {
            return (room) =>
            {
                return new
                {
                    room.RoomNumber,
                    room.Location,
                    room.Capacity,
                    Type = room.Type.ToString(),
                    ReservationDate = room.Reservations!.ToList().Select((reservation) =>
                    {
                        return new
                        {
                            reservation.Begin,
                            reservation.End
                        };

                    }).ToList(),
                    Resources = room.Resources!.ToList().Select((resources) =>
                    {
                        return new
                        {
                            resources.Name,
                            resources.Counts,
                            Type = resources.Type.ToString()
                        };
                    })
                };
            };
        }
    }
}
