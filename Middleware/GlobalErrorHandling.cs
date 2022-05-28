using System.Net;
using System.Text.Json;

namespace Middleware
{
    public class GlobalErrorHandling
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception err)
            {
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;  //burada cast işlemi unboxing işlemidir.
                //switch (err)
                //{
                //    case ApplicationException e:
                //        break;
                //    default:
                //        break;
                //}

                var json = JsonSerializer.Serialize(new 
                { 
                    message = err.Message, 
                    statusCode = (int)HttpStatusCode.InternalServerError 
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
