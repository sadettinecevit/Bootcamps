using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    public class ResponseHeaderAttribute : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public ResponseHeaderAttribute(string name, string value) => (_name, _value) = (name, value);

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_name, _value);
            base.OnResultExecuting(context);
        }
    }

    public class ShortCircuiting : IResourceFilter
    {
        private readonly ILogger _logger;

        public ShortCircuiting(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger("ShortCircuiting");

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogInformation("kljhkö");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogInformation("kljhkö");
            context.Result = new ContentResult
            {
                Content = "dur"
                , StatusCode = 401
            };
        }
    }
}