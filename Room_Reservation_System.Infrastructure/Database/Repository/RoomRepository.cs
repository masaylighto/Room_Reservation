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
using Room_Reservation_System.Core.Comparers.Entity.RoomComparers;
using Room_Reservation_System.Core.ExtensionMethods;

namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private DbSet<Room> _Rooms { get; set; }
        public RoomRepository(DbSet<Room> rooms) : base(rooms)
        {
            _Rooms = rooms;
        }
        public bool IsRoomExisted(int roomNumber)
        {
            return _Rooms.IsExist<Room,CompareRoomNumber>(new Room() { RoomNumber = roomNumber }); ;
        }
    }
}
