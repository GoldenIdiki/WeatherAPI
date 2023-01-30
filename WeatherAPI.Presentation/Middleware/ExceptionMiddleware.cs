using Newtonsoft.Json;
using System.Net;
using WeatherAPI.Domain.Exceptions;
using UnauthorizedAccessException = WeatherAPI.Domain.Exceptions.UnauthorizedAccessException;

namespace WeatherAPI.Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string result = string.Empty;
              
            switch (exception)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case InternalServerErrorException serverError:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
                case UnauthorizedAccessException unauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    break;
            }
            result = result != string.Empty ? result :
                JsonConvert.SerializeObject(new ErrorDetails<object>
                {
                    ShortDescription = exception.Message,
                    Data = null,
                    Code = $"{(int)statusCode}",
                });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
    public class ErrorDetails<TResponse>
    {
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public TResponse Data { get; set; }
    }
}
