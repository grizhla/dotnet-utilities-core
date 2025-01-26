using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Grizhla.UtilitiesCore.Helpers.Converters;
public class HttpStatusCodeJsonConverter : JsonConverter<HttpStatusCode>
{
	public override HttpStatusCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if(string.IsNullOrEmpty(reader.GetString()))
		{
			return HttpStatusCode.InternalServerError;
		}

		return Enum.Parse<HttpStatusCode>(reader.GetString()!);
	}

	public override void Write(Utf8JsonWriter writer, HttpStatusCode value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(((int)value).ToString());
	}
}
