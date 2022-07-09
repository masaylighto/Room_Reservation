using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Core.Response;

namespace Room_Reservation_System.Web.Controllers
{
    [Route("api/reservation/v1/room/")]
    public class RoomController : Controller
    {
        private readonly IRepositoryManager _RepositoryManager;

        public RoomController(IRepositoryManager repositoryManager)
        {
            _RepositoryManager = repositoryManager;
        }
        [HttpPost]
        [Route("Create/")]
        public object CreateRoom([BindRequired]  Core.DataStructure.HttpParameters.RoomInfo room)
        {
           ArgumentNullException.ThrowIfNull(room.RoomNumber);
           ArgumentNullException.ThrowIfNull(room.Location);
           ArgumentNullException.ThrowIfNull(room.Capacity);
           ArgumentNullException.ThrowIfNull(room.Type);
           return HttpResponses.Success(("Created", _RepositoryManager.CreateRoom(room)));
        }

        [HttpPost]
        [Route("Remove/")]
        public object  RemoveRoom( Core.DataStructure.HttpParameters.RoomInfo room)
        {
            ArgumentNullException.ThrowIfNull(room.RoomNumber);
            return HttpResponses.Success(("Removed", _RepositoryManager.RemoveRoom(room)));
        }
    }
}
