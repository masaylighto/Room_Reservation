using Room_Reservation_System.Core.DataStructure.HttpParameters;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Core.WhereClause;
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
        /// Check if the room reserved if the room is not exist it will through exception
        /// </summary>
        /// <param name="roomNumber"></param>
      
   

        public bool IsRoomReserved(RoomReservationInfo paramters)
        {
            if (!_Room.IsRoomExisted(paramters.RoomNumber))
            {
                throw new Exception($"no room with the number {paramters.RoomNumber} exist");
            }
            return _Reservation.IsReservationExist(paramters);
        }
        public bool CreateReservation(RoomReservationInfo paramters)
        {
            if (IsRoomReserved(paramters))
            {
                throw new Exception($"room {paramters.RoomNumber} already reserved at the chosen time");
            }            
            Room chossenRoom = _Room.Get(RoomWhereClause.RoomNumber(paramters.RoomNumber), true).FirstOrDefault()!;
            Reservation reservation = new() 
            {
                id = Guid.NewGuid(),
                Begin = paramters.StartDate,
                End = paramters.EndDate,
                ReservedRoom= chossenRoom,
                RoomId= chossenRoom.Id
            };
            _Reservation.Add(reservation);
             chossenRoom.Reservations.Add(reservation);
            return Save();
        }

        public bool RemoveReservation(RoomReservationInfo paramters)
        {  
            Func<Reservation, bool> matchCondtion = ReservationsWhereClause.WithinDate(paramters);
            _Reservation.Delete(matchCondtion);
            return Save();
        }

        //this method used to provide access to repositories specialized methods 
        public IReservationRepository _Reservation => _LazyReservation.Value;
        public IResourcesRepository _Resources => _LazyResources.Value;
        public IRoomRepository _Room => _LazyRoom.Value;
    }
}
