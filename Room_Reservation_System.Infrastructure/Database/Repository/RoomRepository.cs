using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.Core.Expressions;
using Room_Reservation_System.Core.DataStructure.HttpParameters;

namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class RoomRepository :  IRoomRepository
    {
        private readonly DbSet<Room> _Rooms;
        public RoomRepository(DbSet<Room> rooms) 
        {
            _Rooms = rooms;
        }
        public bool IsExist(int roomNumber)
        {
            return _Rooms.Any(RoomExpressions.RoomNumber(roomNumber)) ;
        }
        public  IEnumerable<Room> Get(Func<Room, bool> expression, bool trackChanges)
        {
            var room = _Rooms.Include(i => i.Reservations).Include(i => i.Resources);
            if (trackChanges)
            {
                return room.AsQueryable<Room>().Where(expression);
            }
            return room.AsNoTracking<Room>().Where(expression);
        }

        public void Add(Room room)
        {
            _Rooms.Add(room);
        }

        public void Delete(Func<Room, bool> expression)
        {
            if (!_Rooms.Any(expression))
            {
                throw new Exception("the room requested to be deleted does not exist ");
            }
            _Rooms.RemoveRange(_Rooms.Where(expression));

        }
    }
}
