using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.Core.Expressions;
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
        public bool IsReservationExist(ReservationInfo paramters)
        { 
            return _Reservations.Include(i=>i.ReservedRoom).Any(ReservationsExpressions.RoomNumberAndDate(paramters));            
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
        /// <summary>
        /// Add New Record
        /// </summary>
        /// <param name="entity"></param>
        public  void Add(Reservation entity)
        {
            _Reservations.Add(entity);
        }
        /// <summary>
        /// Get Records that Match The expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>IQueryable</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Reservation> Get(Func<Reservation, bool> expression,bool trackChanges)
        {
            if (trackChanges)
            {
                return _Reservations.Include(i=>i.ReservedRoom).Where(expression);
            }
            return _Reservations.Include(i => i.ReservedRoom).AsNoTracking().Where(expression);
        }
    }
}
