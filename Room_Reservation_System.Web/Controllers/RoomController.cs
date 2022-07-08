using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Core.Response;
using Room_Reservation_System.Infrastructure.Database.Repository;

namespace Room_Reservation_System.Web.Controllers
{
    public class RoomController : Controller
    {
        IRepositoryManager _RepositoryManager;
        public RoomController(IRepositoryManager repositoryManager)
        {
            _RepositoryManager = repositoryManager;
        }

        [HttpGet]
        [Route("api/reservation/v1/room/IsReserved/")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public object IsRoomReserved(Core.DataStructure.HttpParameters.RoomReservationInfo paramters)
        {            
           return HttpResponses.Success(("IsRoomReserved", _RepositoryManager.IsRoomReserved(paramters)));           
        }
    }
}
