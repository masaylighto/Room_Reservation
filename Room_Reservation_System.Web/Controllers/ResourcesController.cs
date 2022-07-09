using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Core.Response;

namespace Room_Reservation_System.Web.Controllers
{
    [Route("api/reservation/v1/resources/")]
    public class ResourcesController : Controller
    {
        private readonly IRepositoryManager _RepositoryManager;

        public ResourcesController(IRepositoryManager repositoryManager)
        {
            _RepositoryManager = repositoryManager;
        }

    }
}
