using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace BaseCRUDForAPI.Infrastructure
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Request {context.Request.Path} took {stopwatch.ElapsedMilliseconds} ms");
            Console.ResetColor();
        }
    }

}
