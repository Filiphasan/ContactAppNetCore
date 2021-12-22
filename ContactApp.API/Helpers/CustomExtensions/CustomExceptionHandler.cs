using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactApp.API.Helpers.CustomExtensions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var exception = error.Error;
                        var res = new
                        {
                            Message = exception.Message,
                            StatusCode = 500,
                            Status = "error"
                        };
                        await context.Response.WriteAsync(JsonSerializer.Serialize(res));
                    }
                });
            });
        }
    }
}
