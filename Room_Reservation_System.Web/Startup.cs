
using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Infrastructure.Extentions;
using Room_Reservation_System.Web.Middleware;
namespace Room_Reservation_System.Web
{
    public class Startup
    {
        private WebApplicationBuilder _Builder { get; set; }

        public Startup(ref WebApplicationBuilder builder)
        {
            _Builder = builder;
            ConfigureServices();
            Configure();
           
        }
        void ConfigureServices() 
        {
            SetHostConifguration();
            AddServices();           
        }
        void AddServices() 
        {
            AddLogger();
            AddDatabaseService();
            AddControllers();
        }
        void SetHostConifguration() 
        {
            SetAcceptiableContentType();
            UseCors();
        }
        void SetAcceptiableContentType()
        {
            _Builder.Services.Configure<MvcOptions>
                (
                    (Options) =>
                    {
                        Options.Filters.Add(new ConsumesAttribute("application/json"));
                        Options.Filters.Add(new ProducesAttribute("application/json"));
                    }
                );
        }
        void UseCors()
        {
            _Builder.Services.ConfigureCors();
        }
        void AddLogger() 
        {
            _Builder.Services.AddDefaultLogger();
        }
        void AddControllers() 
        {
            _Builder.Services.AddControllers();//.AddNewtonsoftJson(Options=>Options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);          
        }
        void AddDatabaseService() 
        {
             string SqlServerConnection = _Builder.Configuration.GetConnectionString("sqlConnection");
            _Builder.Services.AddSqlServerDb(SqlServerConnection);
        }
        void Configure() {

            WebApplication app = _Builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //catch all the exception through by the application and return them as HTTP response to the caller
            app.UseGlobalErrorHandler();
            app.UseRouting();
            app.UseAuthorization();            
            app.MapControllers();
            app.Run();
        }
    }
}
