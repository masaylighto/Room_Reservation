using Room_Reservation_System.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Entites
{
    public class Resource
    {
        [Required(ErrorMessage = "Resource Id cant be left empty")]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Resource Name can't be empty")]
        public string Name { get; set; }
        public uint Counts { get; set; }

        [Required(ErrorMessage = "Resource Type cant be left empty")]
        public RoomResourceType Type { get; set; }

        //------------------------ Relationship Fields
        [ForeignKey(nameof(Room))]
        [Required(ErrorMessage = "Resource RoomId  navigation property cant be left empty")]
        public Guid RoomId { get; set; }
        [Required(ErrorMessage = "Resource Room  navigation property cant be left empty")]
        public Room? Room { get; set; }

    }
}
