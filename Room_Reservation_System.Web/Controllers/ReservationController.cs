using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Core.Response;
using Room_Reservation_System.Infrastructure.Database.Repository;

namespace Room_Reservation_System.Web.Controllers
{
    [Route("api/reservation/v1/reservation/")]
    public class ReservationController : Controller
    {
        private readonly IRepositoryManager _RepositoryManager;
        public ReservationController(IRepositoryManager repositoryManager)
        {
            _RepositoryManager = repositoryManager;
        }

        [HttpGet]        
        [Route("IsReserved/")]
        public object IsRoomReserved(Core.DataStructure.HttpParameters.ReservationInfo reservationInfo)
        {
            return HttpResponses.Success(("IsDone", _RepositoryManager.IsRoomReserved(reservationInfo)));
        }

        [HttpPost]
        [Route("Create/")]
        public object CreateReservation(Core.DataStructure.HttpParameters.ReservationInfo reservationInfo)
        {
            return HttpResponses.Success(("IsDone", _RepositoryManager.CreateReservation(reservationInfo)));
        }

        [HttpPost]
        [Route("Remove/")]
        public object RemoveReservation(Core.DataStructure.HttpParameters.ReservationInfo reservationInfo)
        {
            return HttpResponses.Success(("IsDone", _RepositoryManager.RemoveReservation(reservationInfo)));
        }

        [HttpGet]
        [Route("RoomReservations/")]       
        public object RoomReservations(Core.DataStructure.HttpParameters.ReservationInfo reservationInfo)
        {           
            return HttpResponses.Success(("RoomReservations", _RepositoryManager.GetRoomReservations(reservationInfo)));
        }
        [HttpGet]
        [Route("Reservations/")]
        public object GetReservations(Core.DataStructure.HttpParameters.ReservationInfo reservationInfo)
        {
            return HttpResponses.Success(("Reservations", _RepositoryManager.AllReservativeDate(reservationInfo)));
        }

    }
}
