using Newtonsoft.Json;
using Room_Reservation_System.Core.Interfaces;

namespace Room_Reservation_System.Web.Middleware
{
    /// <summary>
 /// Catch error that emitted by the different project part and return them as JSON response 
 /// </summary>
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _Next;
        private readonly ILoggingService _Logger;
        private  HttpContext? _HttpContext;
        public GlobalErrorHandler(RequestDelegate next,ILoggingService Logger)
        {
            _Next = next;
            _Logger = Logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                _HttpContext = httpContext;
                await _Next(_HttpContext);
            }
            catch (Exception e)
            {
                //log and return error 
                _Logger.Error(e.Message);
                ReturnFailResponse(e.Message);              
            }            
        }
        /// <summary>
        /// this method write to HTTP response JSON which indicate that requested operation failed
        /// </summary>
        public async void ReturnFailResponse(string Exception)
        {
           var response= new Dictionary<string, string>() { {"State","Failed"},{"Error",Exception} };
           var json = JsonConvert.SerializeObject(response);
           await _HttpContext!.Response.WriteAsync(json);
        }
    }
    public static class GlobalErrorHandlerExtension 
    {
        /// <summary>
        /// Use GlobalErrorHandler Middleware class to  Catch error that emitted by the different project part and return them as JSON response 
        /// </summary>
        public static void UseGlobalErrorHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalErrorHandler>();
        }
    }
}
