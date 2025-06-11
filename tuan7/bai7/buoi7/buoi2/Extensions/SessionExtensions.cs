using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace buoi2.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            if (value != null)
            {
                var json = JsonSerializer.Serialize(value);
                session.SetString(key, json);
            }
        }

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            if (string.IsNullOrEmpty(json))
            {
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (JsonException)
            {
                // Ghi log nếu cần, ví dụ: logger.LogError(...)
                return default;
            }
        }
    }
}
