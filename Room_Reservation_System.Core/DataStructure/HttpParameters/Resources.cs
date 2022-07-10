using Microsoft.AspNetCore.Mvc.ModelBinding;
using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.DataStructure.HttpParameters
{
    public class ResourceInfo 
    {

        [BindRequired]
        public int RoomNumber { get; set; }
        [BindRequired]
        public string? Name { get; set; }
        [BindRequired]
        public uint Counts { get; set; }
        [BindRequired]
        public string? Type { get; set; }
        public static implicit operator Resource(ResourceInfo info)
        { 
            return new () { 
            Id     = Guid.NewGuid(),
            Name   = info.Name,
            Counts = info.Counts,
            Type   = Enum.Parse<Enums.RoomResourceType>(info.Type!,true) 
            };
        }

    }
    public class MoveResourceInfo
    {

        [BindRequired]
        public int SourceRoomNumber { get; set; }
        [BindRequired]
        public int DistinationRoomNumber { get; set; }
        [BindRequired]
        public string? Name { get; set; }
        [BindRequired]
        public uint Counts { get; set; }

    }
}
