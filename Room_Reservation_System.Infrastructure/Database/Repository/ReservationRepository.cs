using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.SharedKernel.Interfaces;
using Room_Reservation_System.Core.Comparers.Entity.ReservationComparer;
using Room_Reservation_System.Core.ExtensionMethods;

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
            //temporary object that will be used to store room number 
            //to use it to check if there is a room with this information
            var compareReservation = new Reservation()
            {
                ReservedRoom = new Room() 
                {
                    RoomNumber = roomNumber
                }
            };
            return true;
            //return _Reservations.IsExist<Reservation, CompareReservationRoomNumber>(compareReservation);
            
        }

       
    }
}
