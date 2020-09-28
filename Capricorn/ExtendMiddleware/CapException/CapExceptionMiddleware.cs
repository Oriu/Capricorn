using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capricorn.ExtendMiddleware.CapException
{
    public class CapExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CapExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/problem+json";

                var title = "An error occured: " + ex.Message;
                var details = ex.ToString();

                var problem = new ProblemDetails
                {
                    Status = 200,
                    Title = title,
                    Detail = details
                };

                //Serialize the problem details object to the Response as JSON (using System.Text.Json)
                var stream = httpContext.Response.Body;
                await JsonSerializer.SerializeAsync(stream, problem);
            }
        }
    }
}
