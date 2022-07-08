using Microsoft.Extensions.DependencyInjection;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Infrastructure.Database.Repository;
using Room_Reservation_System.Infrastructure.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Infrastructure.Extentions
{
    public static class LoggerExtensions
    {
        public static void AddDefaultLogger(this IServiceCollection services)
        {          
            services.AddSingleton<ILoggingService, DefaultLogger>();
        }
    }
}
