using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Infrastructure.Database.Repository;

namespace Room_Reservation_System.Web.Controllers
{
    public class RoomController : Controller
    {
        RepositoryManager _RepositoryManager;
        public RoomController(RepositoryManager repositoryManager)
        {
            _RepositoryManager = repositoryManager;
        }

        [HttpGet]
        [Route("api/reservation/v1/Get")]
        public string GetText()
        {
             
          return "";
        }
    }
}
