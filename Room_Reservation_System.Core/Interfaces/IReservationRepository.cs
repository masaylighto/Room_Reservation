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
        /// <summary>
        /// Check if reservation within the specified date range  and room number is exist
        /// </summary>
        /// <param name="paramters"></param>
        /// <returns>true if exist false other wise</returns>
        bool IsReservationExist(ReservationInfo paramters);
        /// <summary>
        /// Add new Reservation to the database
        /// </summary>
        /// <param name="entity"></param>
         void Add(Reservation entity);
        /// <summary>
        /// Delete the reservation that match the  expression
        /// </summary>
        /// <param name="expression"></param>
        void Delete(Func<Reservation, bool> expression);
        /// <summary>
        /// Get all reservations that match the  expression
        /// </summary>
        /// <param name="expression"></param>
        IEnumerable<Reservation> Get(Func<Reservation, bool> expression,bool trackChanges);
    }
}
