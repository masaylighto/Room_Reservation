using Room_Reservation_System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Expressions
{
    public static class ResourcesSelectClause
    {
        public static Func<Resource, object> Info()
        {
            return (resource) => { return new { resource.Name, resource.Counts, Type = resource.Type.ToString() }; };
        }
    }
    public static class ResourcesWhereClause
    {
        public static Func<Resource, bool> ByName(string Name)
        {
            return (resource) => { return resource.Name == Name; };
        }
    }
}