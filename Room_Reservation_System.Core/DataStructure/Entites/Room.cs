using Room_Reservation_System.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Entites
{
    public class Room
    {
        [Required(ErrorMessage = "Room Id cant be left empty")]
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Room location can't be empty")]
        public string? Location { get; set; }
        [Range(minimum:1,maximum: UInt16.MaxValue,ErrorMessage = "Room Capacity not within the Acceptable range")]
        public UInt16 Capacity { get; set; }
        [Required(ErrorMessage = "Room Type cant be left empty")]
        public RoomType Type { get; set; }

        //------------------------ Relationship Fields
        [Required(ErrorMessage = "Room Resources navigation property cant be left empty")]
        public ICollection<Resource>? Resources { get; set; }
        [Required(ErrorMessage = "Room Reservations navigation property cant be left empty")]
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
