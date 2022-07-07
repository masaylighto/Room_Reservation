using Room_Reservation_System.Core.Validator.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Entites
{
    public class Reservation
    {
        [Required(ErrorMessage = "Reservation Id cant be left empty")]
        public Guid id { get; set; }
        [Required(ErrorMessage = "ReservedRoom navigation property cant be left empty")]
        public Room? ReservedRoom { get; set; }
        [DateTimeRange("time is not within the Acceptable range (8:00 AM - 5:00 PM)", "8:00 AM" ,"5:00 PM")]
        public DateTime Begin { get; set; }
        [DateTimeRange("time is not within the Acceptable range (8:00 AM - 5:00 PM)", "8:00 AM", "5:00 PM")]
        public DateTime End { get; set; }
    }
}
