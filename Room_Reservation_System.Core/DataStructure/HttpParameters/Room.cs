using Microsoft.AspNetCore.Mvc.ModelBinding;
using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.DataStructure.HttpParameters
{
    public class RoomInfo
    {
        
    
        [BindRequired]
        public int RoomNumber { get; set; }
    
        [BindRequired]
        public string? Location { get; set; }
       
        [BindRequired]
        public UInt16 Capacity { get; set; }
       
        [BindRequired]
        public String Type { get; set; }
        public static implicit operator Room(RoomInfo roomCreation) {
            Room room = new();
            room.Capacity = roomCreation.Capacity;
            room.Location = roomCreation.Location;
            room.RoomNumber=roomCreation.RoomNumber;
            room.Type = Enum.Parse<Enums.RoomType>(roomCreation.Type,true);
            return room;
        }
    }

}
