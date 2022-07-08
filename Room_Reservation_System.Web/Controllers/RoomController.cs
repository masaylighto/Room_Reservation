﻿using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Core.Interfaces;

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
    }
}
