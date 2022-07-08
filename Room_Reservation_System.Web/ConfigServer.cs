
using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Infrastructure.Extentions;
using Room_Reservation_System.Web.Middleware;
namespace Room_Reservation_System.Web
{
    public class ConfigServer
    {
        private WebApplicationBuilder _Builder { get; set; }

        public ConfigServer(ref WebApplicationBuilder builder)
        {
            _Builder = builder;
            ConfigServices();
            ConfigPipeline();
           
        }
        void ConfigServices() 
        {

            SetAcceptiableContentType();
            AddLogger();
            AddDatabaseService();
            AddControllers();
            SetConnectionConfiguration();            
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
        void AddLogger() 
        {
            _Builder.Services.AddDefaultLogger();
        }
        void AddControllers() 
        {
            _Builder.Services.AddControllers();//.AddNewtonsoftJson(Options=>Options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);          
        }
        void SetConnectionConfiguration()
        {
            _Builder.Services.ConfigureCors();
        }
        void AddDatabaseService() 
        {
             string SqlServerConnection = _Builder.Configuration.GetConnectionString("sqlConnection");
            _Builder.Services.AddSqlServerDb(SqlServerConnection);
        }
        void ConfigPipeline() {

            WebApplication app = _Builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseGlobalErrorHandler();
            app.UseRouting();
            app.UseAuthorization();            
            app.MapControllers();
            app.Run();
        }
    }
}
