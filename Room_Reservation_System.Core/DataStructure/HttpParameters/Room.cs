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
        public String? Type { get; set; }
        public static implicit operator Room(RoomInfo info) 
        {         
            return new() {
                Capacity   = info.Capacity,
                Location   = info.Location,
                RoomNumber = info.RoomNumber,
                Type       = Enum.Parse<Enums.RoomType>(info.Type!, true)
            };
        }
    }

}
