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
        [HttpPost]
        [Route("Add/")]
        public object Add(Core.DataStructure.HttpParameters.ResourceInfo resource)
        {            
            return HttpResponses.Success(("Reservations", _RepositoryManager.AddResource(resource)));
        }
        [HttpGet]
        [Route("Get/")]
        public object Get(Core.DataStructure.HttpParameters.ResourceInfo resource)
        {
            return HttpResponses.Success(("Reservations", _RepositoryManager.GetRoomResource(resource)));
        }
        [HttpGet]
        [Route("Move/")]
        public object MoveResource(Core.DataStructure.HttpParameters.MoveResourceInfo resource)
        {
            return HttpResponses.Success(("Reservations", _RepositoryManager.MoveResource(resource)));
        }
    }
}
