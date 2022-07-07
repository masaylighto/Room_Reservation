using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Core.Interfaces;
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
        [Route("api/reservation/v1/Get")]
        public string GetText()
        {
            _RepositoryManager.Reservation.IsRoomReserved(522);
          return "";
        }
    }
}
