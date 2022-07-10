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
        public bool IsRoomReserved(ReservationInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            ArgumentNullException.ThrowIfNull(info.StartDate);
            ArgumentNullException.ThrowIfNull(info.EndDate);
            return _Reservation.IsReservationExist(info);
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
            //get room attach it into the resource and add the resource into it
            Room room = _Room.Get(RoomWhereClause.RoomNumber(ReservationInfo.RoomNumber), true).FirstOrDefault()!;
            Reservation reservation = ReservationInfo;
            reservation.RoomId = room.Id;
            reservation.ReservedRoom = room;
            _Reservation.Add(reservation);
            room.Reservations!.Add(reservation);
        }
        public bool CreateReservation(ReservationInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.Owner);
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            ArgumentNullException.ThrowIfNull(info.StartDate);
            ArgumentNullException.ThrowIfNull(info.EndDate);
            EnsureRoomExist(info.RoomNumber);
            EnsureRoomNotReserved(info);
            AddRoomReservation(info);
            return Save();
        }

        public bool RemoveReservation(ReservationInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            ArgumentNullException.ThrowIfNull(info.StartDate);
            ArgumentNullException.ThrowIfNull(info.EndDate);
            Func<Reservation, bool> matchCondtion = ReservationsWhereClause.RoomNumberAndDate(info);
            _Reservation.Delete(matchCondtion);
            return Save();
        }

        public object GetRoomReservations(ReservationInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            EnsureRoomExist(info.RoomNumber);
            return _Reservation
                .Get(ReservationsWhereClause.RoomNumber(info.RoomNumber),false)
                .Select(ReservationsSelectClause.Info())
                .ToList();
        }

        public object AllReservativeDate(ReservationInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.StartDate);
            ArgumentNullException.ThrowIfNull(info.EndDate);
            return _Reservation
                 .Get(ReservationsWhereClause.DateRange(info.StartDate, info.EndDate), false)
                 .Select(ReservationsSelectClause.Info())
                 .ToList();
        }

        public bool CreateRoom(RoomInfo info)
        {

            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            ArgumentNullException.ThrowIfNull(info.Location);
            ArgumentNullException.ThrowIfNull(info.Capacity);
            ArgumentNullException.ThrowIfNull(info.Type);
            EnsureRoomNotExist(info.RoomNumber);
             _Room.Add(info);
            return Save();
        }

        public bool RemoveRoom(RoomInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            EnsureRoomExist(info.RoomNumber);
            _Room.Delete(RoomWhereClause.RoomNumber(info.RoomNumber));
            return Save();
        }

        public object GetRooms()
        {
            return _Room.Get(false).ToList()
                    .Select(RoomSelectClause.Info());
        }

        public object GetRoom(RoomInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            EnsureRoomExist(info.RoomNumber);
            return _Room.Get(RoomWhereClause.RoomNumber(info.RoomNumber),false)
                    .Select(RoomSelectClause.Info());
        }

        public bool AddResource(ResourceInfo info)
        {
            //get room attach it into resource into it and add resource into it
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            ArgumentNullException.ThrowIfNull(info.Name);
            ArgumentNullException.ThrowIfNull(info.Counts);
            ArgumentNullException.ThrowIfNull(info.Type);
            EnsureRoomExist(info.RoomNumber);
            Room room =_Room.Get(RoomWhereClause.RoomNumber(info.RoomNumber),true).First();
            Resource resource = info;
            resource.Room = room;
            resource.RoomId = room.Id;
            _Resources.Add(resource);
            return Save();
        }

        public object GetRoomResource(ResourceInfo info)
        {
            ArgumentNullException.ThrowIfNull(info.RoomNumber);
            EnsureRoomExist(info.RoomNumber);
            Room room = _Room.Get(RoomWhereClause.RoomNumber(info.RoomNumber), true).First();
            return room.Resources!.Select(ResourcesSelectClause.Info());
        }

        public bool MoveResource(MoveResourceInfo info)
        {
            /*
                get the source room then get its resource check if the exist and movable 
                detach them from the source room 
                link them to the destination room             
             */
            ArgumentNullException.ThrowIfNull(info.SourceRoomNumber);
            ArgumentNullException.ThrowIfNull(info.DistinationRoomNumber);
            ArgumentNullException.ThrowIfNull(info.Name);
            ArgumentNullException.ThrowIfNull(info.Counts);
            EnsureRoomExist(info.SourceRoomNumber);
            EnsureRoomExist(info.DistinationRoomNumber);
            Room SourceRoom = _Room.Get(RoomWhereClause.RoomNumber(info.SourceRoomNumber), true).First();
            Room DistinationRoom = _Room.Get(RoomWhereClause.RoomNumber(info.DistinationRoomNumber), true).First();
            Resource? resources = SourceRoom.Resources!.FirstOrDefault(ResourcesWhereClause.ByName(info.Name));
            if (resources is null)
            {
                throw new Exception($"no resources with the name {info.Name} in the room {info.SourceRoomNumber}");
            }
            if (resources.Type==Core.Enums.RoomResourceType.ImMovable)
            {
                throw new Exception($" resources with the name {info.Name} in the room {info.SourceRoomNumber} is immovable resouce");
            }
            resources.Room = DistinationRoom;
            resources.RoomId = DistinationRoom.Id;
            SourceRoom.Resources!.Remove(resources);
            DistinationRoom.Resources!.Add(resources);
            return Save();
        }


        //this method used to provide access to repositories specialized methods 
        private IReservationRepository _Reservation => _LazyReservation.Value;
        private IResourcesRepository _Resources => _LazyResources.Value;
        private IRoomRepository _Room => _LazyRoom.Value;
    }
}
