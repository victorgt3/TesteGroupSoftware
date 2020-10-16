using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace GroupSoftware.Domain.DependencyInjection.Configuration.ErroHandler
{
    public class ErroHandlerSupport
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErroHandlerSupport> _logger;

        public ErroHandlerSupport(RequestDelegate next, ILogger<ErroHandlerSupport> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception e)
        {
            ErroHandlerLog log = new ErroHandlerLog()
            {
                Host = context.Request.Host.Value,
                Method = context.Request.Method,
                Path = context.Request.Path,
                Source = e.Source,
                Message = e.Message,
                StackTrace = e.StackTrace,
                InnerException = e.InnerException?.ToString().Replace("System.Exception: ", "")
            };
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            context.Response.Clear();
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            context.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            var result = JsonConvert.SerializeObject(new ErroHandlerResponse()
            {
                InnerException = e.InnerException,
                Message = e.Message,
                Code = 500
            }, serializerSettings);
            _logger.LogError(JsonConvert.SerializeObject(log, serializerSettings));
            return context.Response.WriteAsync(result);
        }
    }
}
