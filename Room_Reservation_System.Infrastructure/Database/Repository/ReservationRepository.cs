using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.SharedKernel.Interfaces;

namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public DbSet<Reservation> _Reservations;
        public ReservationRepository(DbSet<Reservation> _reservations) : base(ref _reservations)
        {
            _Reservations = _reservations;
        }

        public bool IsRoomReserved(int roomNumber)
        {            
            return _Reservations.AsNoTracking().Include(i => i.ReservedRoom).Where(entry => entry.ReservedRoom.RoomNumber == roomNumber).FirstOrDefault() == null;
            
        }

       
    }
}
