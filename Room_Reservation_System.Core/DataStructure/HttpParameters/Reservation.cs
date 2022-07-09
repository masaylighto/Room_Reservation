using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.DataStructure.HttpParameters
{   /// <summary>
    /// used to bind HTTP request parameters
    /// </summary>
    public class ReservationInfo
    {
        [BindRequired]
        public int RoomNumber { get; set; }
        [BindRequired]
        public DateTime StartDate { get; set; }
        [BindRequired]
        public DateTime EndDate { get; set; }
    }
}
