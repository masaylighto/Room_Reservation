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
using Room_Reservation_System.SharedKernel.Interfaces;
using Room_Reservation_System.Core.ExtensionMethods;
using Room_Reservation_System.Core.WhereClause;

namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly DbSet<Room> _Rooms;
        public RoomRepository(DbSet<Room> rooms) : base(rooms)
        {
            _Rooms = rooms;
        }
        public bool IsRoomExisted(int roomNumber)
        {
            return _Rooms.Any(RoomWhereClause.RoomNumber(roomNumber)) ;
        }
        public override IEnumerable<Room> Get(Func<Room, bool> expression, bool trackChanges)
        {
            var room = _Rooms.Include(i => i.Reservations).Include(i => i.Resources);
            if (trackChanges)
            {
                return room.AsQueryable<Room>().Where(expression);
            }
            return room.AsNoTracking<Room>().Where(expression);
        }
   
    }
}
