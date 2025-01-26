using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Grizhla.UtilitiesCore.Helpers.Converters;
public class DecimalJsonConverter : JsonConverter<Decimal>
{
	public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if(string.IsNullOrEmpty(reader.GetString()))
			return 0;
		return Decimal.Parse(reader.GetString());

	}

	public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToString("n6"));

	}
}
