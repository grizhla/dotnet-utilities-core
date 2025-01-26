using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Grizhla.UtilitiesCore.Helpers.Converters;

namespace Grizhla.UtilitiesCore.API.Models;
public class ProcessResult<T>
{
	public bool Success { get; set; }

	public string Message { get; set; } = null!;

	public T? Model { get; set; }

	[JsonConverter(typeof(HttpStatusCodeJsonConverter))]
	public HttpStatusCode StatusCode { get; set; }

	[JsonConverter(typeof(HttpStatusCodeJsonConverter))]
	public const HttpStatusCode DefaultFailureStatusCode = HttpStatusCode.InternalServerError;

	public static ProcessResult<T> Processed(T? data = default, string message = "")
	{
		return new ProcessResult<T>
		{
			StatusCode = HttpStatusCode.OK,
			Success = true,
			Model = data,
			Message = message,
		};
	}

	public static ProcessResult<T> ProcessFailed(HttpStatusCode statusCode = DefaultFailureStatusCode, string message = "")
	{
		return new ProcessResult<T>
		{
			StatusCode = statusCode,
			Success = false,
			Message = message,
		};
	}
}
