using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capricorn.ExtendMiddleware.CapException
{
    public class CapExceptionHandler
    {
        //该内容会在AspNetCore的管道返回结果至ExceptionHandlerMiddleware时，如果中间件捕获到了异常时调用
        public async Task ExceptionHandler(HttpContext httpContext, Func<Task> next)
        {
            //该信息由ExceptionHandlerMiddleware中间件提供，里面包含了ExceptionHandlerMiddleware中间件捕获到的异常信息。
            var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionDetails?.Error;

            if (ex != null)
            {
                httpContext.Response.ContentType = "application/problem+json";

                var title = "An error occured: " + ex.Message;
                var details = ex.ToString();

                var problem = new ProblemDetails
                {
                    Status = 500,
                    Title = title,
                    Detail = details
                };

                var stream = httpContext.Response.Body;
                await JsonSerializer.SerializeAsync(stream, problem);
            }
        }
    }
}
