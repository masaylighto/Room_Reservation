using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Exceptions
{
    public class NullValue : Exception
    {

        public NullValue(string? message) : base(message)
        {

        }
    }
}
