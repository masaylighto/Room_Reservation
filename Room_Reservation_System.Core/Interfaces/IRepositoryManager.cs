using Room_Reservation_System.Core.DataStructure.HttpParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Interfaces
{
    public interface IRepositoryManager
    {
        /// <summary>
        /// Check if the room specified With room number in ReservationInfo is reserved during 
        /// range of Date Specified in ReservationInfo
        /// </summary>
        /// <param name="Paramters"></param>
        /// <returns>boolean</returns>
        public bool IsRoomReserved(ReservationInfo Paramters);
        /// <summary>
        /// Save Changes into Database
        /// </summary>
        /// <returns>boolean indicate if the operation succeed</returns>
        bool Save();
        /// <summary>
        /// Create A new Reservation for the specified room and within the specified date range in ReservationInfo
        /// </summary>
        /// <param name="paramters"></param>
        /// <returns>boolean indicate if the operation succeed</returns>
        bool CreateReservation(ReservationInfo paramters);
        /// <summary>
        /// remove the reservation of the specified room and within the specified date range in ReservationInfo
        /// </summary>
        /// <param name="paramters"></param>
        /// <returns>boolean indicate if the operation succeed</returns>
        bool RemoveReservation(ReservationInfo paramters);
        /// <summary>
        /// Get Reservation that attached to the room specified with room number in ReservationInfo
        /// </summary>
        /// <param name="info"></param>
        /// <returns>Dictionary That Hold all the returned information</returns>
        object GetRoomReservations(ReservationInfo info);
        /// <summary>
        /// get all the reservation that accrue within the specified date range
        /// </summary>
        /// <param name="info"></param>
        /// <returns>Dictionary That Hold all the returned information</returns>
        object AllReservativeDate(ReservationInfo info);
        /// <summary>
        /// Create room with the specified information in RoomInfo
        /// </summary>
        /// <param name="room"></param>
        /// <returns>boolean indicate if the operation succeed</returns>
        bool CreateRoom(RoomInfo room);
        /// <summary>
        /// remove room with the specified room number in RoomInfo
        /// </summary>
        /// <param name="room"></param>
        /// <returns>boolean indicate if the operation succeed</returns>
        bool RemoveRoom(RoomInfo room);
        /// <summary>
        /// Get All Rooms and their informations
        /// </summary>
        /// <returns>Dictionary That Hold all the returned information</returns>
        object GetRooms();
        /// <summary>
        /// get the information of the room that specified with the room number in RoomInfo
        /// </summary>
        /// <param name="room"></param>
        /// <returns>Dictionary That Hold all the returned information</returns>
        object GetRoom(RoomInfo room);
        /// <summary>
        /// Add Resource to the room specified with the room number in ResourceInfo 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns>boolean indicate if the operation succeed</returns>
        bool AddResource(ResourceInfo resource);
        /// <summary>
        /// Get Resource of the room specified with the room number in ResourceInfo 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns>Dictionary That Hold all the returned information</returns>
        object GetRoomResource(ResourceInfo info);
        /// <summary>
        /// move the resource specified by name from the room specified by SourceRoomNumber 
        /// to the room specified by DistinationRoomNumber 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns>boolean indicate if the operation succeed</returns>
        bool MoveResource(MoveResourceInfo resource);
    }
}
