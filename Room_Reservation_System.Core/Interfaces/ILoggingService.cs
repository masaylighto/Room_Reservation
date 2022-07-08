using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Interfaces
{
 
        public interface ILoggingService
        {
            void Info(string message);
            void Warn(string message);
            void Debug(string message);
            void Error(string message);
        
        }
}
