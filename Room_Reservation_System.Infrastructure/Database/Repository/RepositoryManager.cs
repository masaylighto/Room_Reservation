using Room_Reservation_System.Core.DataStructure.HttpParameters;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Core.Expressions;
using Room_Reservation_System.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Room_Reservation_System.Infrastructure.Database.Repository
{   
    
    public sealed class RepositoryManager : IRepositoryManager
    {

        private readonly Lazy<IReservationRepository> _LazyReservation;
        private readonly Lazy<IResourcesRepository> _LazyResources;
        private readonly Lazy<IRoomRepository> _LazyRoom;            
        private readonly BaseContext _baseContext;
     
        public RepositoryManager(BaseContext baseContext)
        {
            _LazyReservation = new Lazy<IReservationRepository>(() => new ReservationRepository(baseContext.Set<Reservation>()));
            _LazyResources = new Lazy<IResourcesRepository>(() => new ResourceRepository(baseContext.Set<Resource>()));
            _LazyRoom = new Lazy<IRoomRepository>(() => new RoomRepository(baseContext.Set<Room>()));
            _baseContext = baseContext;
        }
        /// <summary>
        /// Save Change to Database
        /// </summary>
        /// <returns> True if the operation Succeed</returns>
        public bool Save()
        {
            return _baseContext.SaveChanges()>0;
        }
        /// <summary>
        ///  Will Through Exception if room isnt exist
        /// </summary>
        /// <param name="roomNumber"></param>
        private void EnsureRoomExist(int roomNumber)
        {
            if (!_Room.IsExist(roomNumber))
            {
                throw new Exception($"no room with the number {roomNumber} exist");
            }
        }
        public bool IsRoomReserved(RoomReservationInfo paramters)
        {           
            return _Reservation.IsReservationExist(paramters);
        }
        /// <summary>
        /// Through Exception If Room Reserved
        /// </summary>
        /// <param name="paramters"></param>
        /// <exception cref="Exception"></exception>
       private void EnsureRoomNotReserved(RoomReservationInfo paramters)
        {
            if (IsRoomReserved(paramters))
            {
                throw new Exception($"room {paramters.RoomNumber} already reserved at the chosen time");
            }
        }
       private void AddRoomReservation(RoomReservationInfo paramters)
        {
            Room room = _Room.Get(RoomExpressions.RoomNumber(paramters.RoomNumber), true).FirstOrDefault()!;
            Reservation reservation = new()
            {
                id = Guid.NewGuid(),
                Begin = paramters.StartDate,
                End = paramters.EndDate,
                ReservedRoom = room,
                RoomId = room.Id
            };
            _Reservation.Add(reservation);
            room.Reservations!.Add(reservation);
        }
        public bool CreateReservation(RoomReservationInfo paramters)
        {
            EnsureRoomExist(paramters.RoomNumber);
            EnsureRoomNotReserved(paramters);
            AddRoomReservation(paramters);
            return Save();
        }

        public bool RemoveReservation(RoomReservationInfo paramters)
        {  
            Func<Reservation, bool> matchCondtion = ReservationsExpressions.RoomNumberAndDate(paramters);
            _Reservation.Delete(matchCondtion);
            return Save();
        }

        public object RoomReservations(int roomNumber)
        {
           EnsureRoomExist(roomNumber);
           return _Reservation
                .Get(ReservationsExpressions.RoomNumber(roomNumber),false)
                .Select((S)=> { return new { S.ReservedRoom.RoomNumber ,S.Begin,S.End }; })
                .ToList();
        }

        //this method used to provide access to repositories specialized methods 
        public IReservationRepository _Reservation => _LazyReservation.Value;
        public IResourcesRepository _Resources => _LazyResources.Value;
        public IRoomRepository _Room => _LazyRoom.Value;
    }
}
