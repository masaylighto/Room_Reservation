using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Infrastructure.Database.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<BaseContext>
    {
        public BaseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<BaseContext>()
                 .UseSqlServer(configuration.GetConnectionString("sqlConnection"), option => option.MigrationsAssembly("Room_Reservation_System.Web"));
            return new BaseContext(builder.Options);
        }
    }
}
