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
        public object IsRoomReserved(Core.DataStructure.HttpParameters.RoomReservationInfo paramters)
        {
            return HttpResponses.Success(("IsRoomReserved", _RepositoryManager.IsRoomReserved(paramters)));
        }

        [HttpPost]
        [Route("Create/")]
        public object CreateReservation(Core.DataStructure.HttpParameters.RoomReservationInfo paramters)
        {
            return HttpResponses.Success(("IsReservationSucceed", _RepositoryManager.CreateReservation(paramters)));
        }

        [HttpPost]
        [Route("Remove/")]
        public object RemoveReservation(Core.DataStructure.HttpParameters.RoomReservationInfo paramters)
        {
            return HttpResponses.Success(("IsRemoveSucceed", _RepositoryManager.RemoveReservation(paramters)));
        }

        [HttpGet]
        [Route("RoomReservations/")]       
        public object RoomReservations([BindRequired] int roomNumber)
        {
            return HttpResponses.Success(("RoomReservations", _RepositoryManager.RoomReservations(roomNumber)));
        }
    }
}
