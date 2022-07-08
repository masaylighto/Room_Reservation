using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.Core.ExtensionMethods;
using Room_Reservation_System.Core.WhereClause;
using Room_Reservation_System.Core.DataStructure.HttpParameters;

namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class ReservationRepository :  IReservationRepository
    {
        public readonly DbSet<Reservation> _Reservations;
        public ReservationRepository(DbSet<Reservation> _reservations) 
        {
            _Reservations = _reservations;
        
        }

   


        /// <summary>
        /// this method only check if there is a reservation with this room number 
        /// it doesn't care if there is a room with this number in the database
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public bool IsReservationExist(RoomReservationInfo paramters)
        { 
            return _Reservations.Include(i=>i.ReservedRoom).Any(ReservationsWhereClause.WithinDate(paramters));            
        }
        /// <summary>
        /// Delete All Entity That Match the expression
        /// </summary>
        /// <param name="expression"></param>
        public  void Delete(Func<Reservation, bool> expression)
        {

            if (!_Reservations.Include(i => i.ReservedRoom).Any(expression))
            {
                throw new Exception("the records requested to be deleted does not exist ");
            }
            _Reservations.RemoveRange(_Reservations.Include(i => i.ReservedRoom).Where(expression));
        }
        public  void Add(Reservation entity)
        {
            _Reservations.Add(entity);
        }
    }
}
