using System;
using System.Net.Http;
using System.Text.Json;

namespace Front
{
    public static class RequestHelper
    {
        public static HttpRequestMessage CreateRequest(string uri, string method)
            => new HttpRequestMessage(method.ToHttpMethod(), new Uri(uri, UriKind.RelativeOrAbsolute));

        public static T? Deserialize<T>(this string source)
            => JsonSerializer.Deserialize<T>(source, Options);

        private static JsonSerializerOptions Options { get; } = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true
        };

        private static HttpMethod ToHttpMethod(this string method)
            => method switch
            {
                "GET" => HttpMethod.Get,
                "PUT" => HttpMethod.Put,
                "POST" => HttpMethod.Post,
                "DELETE" => HttpMethod.Delete,
                "HEAD" => HttpMethod.Head,
                "PATCH" => HttpMethod.Patch,
                "TRACE" => HttpMethod.Trace,
                _ => HttpMethod.Options
            };
    }
}