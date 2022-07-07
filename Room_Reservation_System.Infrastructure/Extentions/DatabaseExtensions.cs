using Microsoft.Extensions.DependencyInjection;
using Room_Reservation_System.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Infrastructure.Database.Repository;

namespace Room_Reservation_System.Infrastructure.Extentions
{
    public static class DatabaseExtensions
    {
        public static void AddSqlServerDb(this IServiceCollection services,string DatabaseConnection) 
        {
            services.AddDbContext<BaseContext>(option =>option.UseSqlServer(DatabaseConnection));
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
      
    }
}
