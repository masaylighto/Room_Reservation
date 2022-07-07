﻿using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room_Reservation_System.SharedKernel.Interfaces;
namespace Room_Reservation_System.Core.Interfaces
{
    public interface IReservationRepository: IBaseRepository<Reservation>
    {
        bool IsRoomReserved(int roomNumber);
    }
}