using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.Core.DataStructure.HttpParameters;
using Room_Reservation_System.Core.Entites;
namespace Room_Reservation_System.Core.Interfaces
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Get all Room that match the  expression
        /// </summary>
        /// <param name="expression"></param>
        public IEnumerable<Room> Get(Func<Room, bool> expression, bool trackChanges);
        /// <summary>
        /// Check if the room with the Specified room number is exist
        /// </summary>
        /// <param name="expression"></param>
        bool IsExist(int roomNumber);
        void Add(Room room);
        /// <summary>
        /// Delete all Room that match the expression
        /// </summary>
        /// <param name="expression"></param>
        void Delete(Func<Room, bool> expression);
        /// <summary>
        /// Get all Room 
        /// </summary>
        /// <param name="expression"></param>
        IQueryable<Room> Get(bool trackChanges);
    }
}
