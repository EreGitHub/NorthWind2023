﻿namespace NorthWind.Exceptions.Entities.Extensions;

internal static class HttpContextExtensions
{
    public static async ValueTask WriteProblemDetails(this HttpContext context, ProblemDetails details)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = details.Status.Value;

        var Stream = context.Response.Body;
        await JsonSerializer.SerializeAsync(Stream, details);
    }
}
