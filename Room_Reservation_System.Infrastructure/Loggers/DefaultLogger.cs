using NLog;
using Room_Reservation_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Infrastructure.Loggers
{
    public class DefaultLogger: ILoggingService
    {
        private static ILogger _Logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message) => _Logger.Debug(message);

        public void Error(string message) => _Logger.Error(message);

        public void Info(string message) => _Logger.Info(message);

        public void Warn(string message) => _Logger.Warn(message);
    }
}
