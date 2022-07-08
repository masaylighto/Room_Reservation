﻿using Room_Reservation_System.Core.DataStructure.HttpParameters;
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

        private readonly Lazy<IReservationRepository> _Reservation;
        private readonly Lazy<IResourcesRepository> _Resources;
        private readonly Lazy<IRoomRepository> _Room;            
        private readonly BaseContext _baseContext;
     
        public RepositoryManager(BaseContext baseContext)
        {
            _Reservation = new Lazy<IReservationRepository>(() => new ReservationRepository(baseContext.Set<Reservation>()));
            _Resources = new Lazy<IResourcesRepository>(() => new ResourceRepository(baseContext.Set<Resource>()));
            _Room = new Lazy<IRoomRepository>(() => new RoomRepository(baseContext.Set<Room>()));
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
      
        public void ReserveRoom(int RoomId,DateTime StartDate,DateTime EndDate)
        {
       
        }

        public bool IsRoomReserved(RoomReservationInfo paramters)
        {
            if (!Room.IsRoomExisted(paramters.RoomNumber))
            {
                throw new Exception($"no room with the number {paramters.RoomNumber} exist");
            }
            return Reservation.IsRoomReserved(paramters);
        }

        public bool CreateReservation(RoomReservationInfo paramters)
        {
            if (IsRoomReserved(paramters))
            {
                throw new Exception($"room already reserved at the chosen time");
            }
            Room ChossenRoom = Room.Get(RoomWhereClause.RoomNumber(paramters.RoomNumber), true).First();
            Reservation reservation = new() 
            {
                id = Guid.NewGuid(),
                Begin = paramters.StartDate,
                End = paramters.EndDate,
                ReservedRoom= ChossenRoom,
                RoomId= ChossenRoom.Id
            };
            Reservation.Add(reservation);
            ChossenRoom.Reservations.Add(reservation);
            return Save();
        }

        //this method used to provide access to repositories specialized methods 
        public IReservationRepository Reservation => _Reservation.Value;
        public IResourcesRepository Resources => _Resources.Value;
        public IRoomRepository Room => _Room.Value;
    }
}
