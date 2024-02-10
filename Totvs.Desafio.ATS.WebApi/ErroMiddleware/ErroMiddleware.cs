using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Totvs.Desafio.ATS.WebApi.ErroMiddleware;

public class ErroMiddleware
{
    private readonly RequestDelegate next;

    public ErroMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExcecaoAsync(context, ex);
        }
    }

    private Task HandleExcecaoAsync(HttpContext context, Exception ex)
    {
        ErroResponses erroResponses;

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Qa")
        {
            erroResponses = new ErroResponses(HttpStatusCode.InternalServerError.ToString(),
                                                      $"{ex.Message} {ex?.InnerException?.Message}");
        }
        else
        {
            erroResponses = new ErroResponses(HttpStatusCode.InternalServerError.ToString(),
                                                      "An internal server error has occurred.");        }

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = JsonConvert.SerializeObject(erroResponses);
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}

