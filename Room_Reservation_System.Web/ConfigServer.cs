
using Microsoft.AspNetCore.Mvc;
using Room_Reservation_System.Infrastructure.Extentions;

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
            SetConnectionConfiguration();
        }
        void ConfigServices() 
        {
            AddDatabaseService();
            AddControllers();
        }
     
        void AddControllers() 
        {
            _Builder.Services.AddControllers();          
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
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
