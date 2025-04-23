using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Grizhla.UtilitiesCore.Helpers.Converters;

namespace Grizhla.UtilitiesCore.API.Models;

public class GrizhlaResult<T>
{
    public T? Model { get; set; }

    public bool Success { get; set; }

    public string Message { get; set; } = null!;

    public string Description { get; set; } = null!;

    [JsonConverter(typeof(HttpStatusCodeJsonConverter))]
    public HttpStatusCode StatusCode { get; set; }

    [JsonConverter(typeof(HttpStatusCodeJsonConverter))]
    public const HttpStatusCode DefaultFailureStatusCode = HttpStatusCode.InternalServerError;

    public static GrizhlaResult<T> Processed(
        T? data = default,
        string message = "",
        string description = ""
    )
    {
        return new GrizhlaResult<T>
        {
            StatusCode = HttpStatusCode.OK,
            Success = true,
            Model = data,
            Message = message,
            Description = description,
        };
    }

    public static GrizhlaResult<T> ProcessFailed(
        HttpStatusCode statusCode = DefaultFailureStatusCode,
        string message = "",
        string description = ""
    )
    {
        return new GrizhlaResult<T>
        {
            StatusCode = statusCode,
            Success = false,
            Message = message,
            Description = description,
        };
    }
}
