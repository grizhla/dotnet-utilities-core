using System.Text.Json.Serialization;
using System.Text.Json;

namespace dotnet_utilities_core.Base.JsonUtilities;

public static partial class JsonSerializerUtility
{
	public static JsonSerializerOptions GetJsonSerializerOptions(JsonSerializerOptions? options = null)
	{
		options ??= new JsonSerializerOptions();
		options.AllowTrailingCommas = true;
		options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		return options;
	}

	public static string Serialize(object data, JsonSerializerOptions? options = null) => JsonSerializer.Serialize(data, GetJsonSerializerOptions(options));

	public static async Task<string> SerializeAsync(object data, JsonSerializerOptions? options = null) => await Task.Run(() => Serialize(data, GetJsonSerializerOptions(options)));

	public static T? Deserialize<T>(string json, JsonSerializerOptions? options = null) => JsonSerializer.Deserialize<T>(json, GetJsonSerializerOptions(options));

	public static async Task<T?> DeserializeAsync<T>(string json, JsonSerializerOptions? options = null) => await Task.Run(() => Deserialize<T>(json, GetJsonSerializerOptions()));
}
