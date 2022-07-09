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
        ///  Will Through Exception if room isn't exist
        /// </summary>
        /// <param name="roomNumber"></param>
        private void EnsureRoomExist(int roomNumber)
        {
            if (!_Room.IsExist(roomNumber))
            {
                throw new Exception($"no room with the number {roomNumber} exist");
            }
        }
        /// <summary>
        ///  Will Through Exception if room  exist
        /// </summary>
        /// <param name="roomNumber"></param>
        private void EnsureRoomNotExist(int roomNumber)
        {
            if (_Room.IsExist(roomNumber))
            {
                throw new Exception($" room with the number {roomNumber} already exist");
            }
        }
        public bool IsRoomReserved(ReservationInfo paramters)
        {           
            return _Reservation.IsReservationExist(paramters);
        }
        /// <summary>
        /// Through Exception If Room Reserved
        /// </summary>
        /// <param name="paramters"></param>
        /// <exception cref="Exception"></exception>
       private void EnsureRoomNotReserved(ReservationInfo paramters)
        {
            if (IsRoomReserved(paramters))
            {
                throw new Exception($"room {paramters.RoomNumber} already reserved at the chosen time");
            }
        }
       private void AddRoomReservation(ReservationInfo ReservationInfo)
        {
            Room room = _Room.Get(RoomExpressions.RoomNumber(ReservationInfo.RoomNumber), true).FirstOrDefault()!;
            Reservation reservation = ReservationInfo;
            reservation.RoomId = room.Id;
            reservation.ReservedRoom = room;
            _Reservation.Add(reservation);
            room.Reservations!.Add(reservation);
        }
        public bool CreateReservation(ReservationInfo paramters)
        {
            EnsureRoomExist(paramters.RoomNumber);
            EnsureRoomNotReserved(paramters);
            AddRoomReservation(paramters);
            return Save();
        }

        public bool RemoveReservation(ReservationInfo paramters)
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
                .Select((S)=> { return new { S.ReservedRoom.RoomNumber ,S.Begin,S.End,S.Owner }; })
                .ToList();
        }

        public object Reservations(DateTime startDate, DateTime endDate)
        {             
            return _Reservation
                 .Get(ReservationsExpressions.DateRange(startDate, endDate), false)
                 .Select((S) => { return new { S.ReservedRoom!.RoomNumber, S.Begin, S.End, S.Owner }; })
                 .ToList();
        }

        public bool CreateRoom(RoomInfo room)
        {
            EnsureRoomNotExist(room.RoomNumber);
             _Room.Add(room);
            return Save();
        }

        public bool RemoveRoom(RoomInfo room)
        {
            EnsureRoomExist(room.RoomNumber);
            _Room.Delete(RoomExpressions.RoomNumber(room.RoomNumber));
            return Save();
        }

        public object GetRooms()
        {
            return _Room.Get(false).ToList()
                    .Select((S) => 
                    {
                        return new { S.RoomNumber, S.Location, S.Capacity ,Type=S.Type.ToString() };
                    });
        }

        public object GetRoom(RoomInfo roomInfo)
        {
            return _Room.Get(RoomExpressions.RoomNumber(roomInfo.RoomNumber),false)
                    .Select((room) =>
                    {
                        return new {
                            room.RoomNumber,
                            room.Location,
                            room.Capacity,
                            Type = room.Type.ToString() ,
                            ReservationDate=  room.Reservations.ToList().Select((reservation)=> 
                            {
                                return new 
                                {
                                    reservation.Begin,
                                    reservation.End
                                };
                               
                            }).ToList(),
                            Resources = room.Resources.ToList().Select((resources) => 
                            {
                                return new
                                {
                                    resources.Name,
                                    resources.Counts,
                                    Type = resources.Type.ToString()
                                };
                            })
                        };
                    });
        }


        //this method used to provide access to repositories specialized methods 
        public IReservationRepository _Reservation => _LazyReservation.Value;
        public IResourcesRepository _Resources => _LazyResources.Value;
        public IRoomRepository _Room => _LazyRoom.Value;
    }
}
