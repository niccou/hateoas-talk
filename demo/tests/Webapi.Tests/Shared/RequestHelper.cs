using System.Text.Json;

namespace WebApi.Tests.Shared
{
    public static class RequestHelper
    {
        private static JsonSerializerOptions Options { get; } = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true
        };

        public static T? Deserialize<T>(this string source)
            => JsonSerializer.Deserialize<T>(source, Options);
    }
}
