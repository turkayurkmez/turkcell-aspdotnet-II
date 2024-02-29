using Newtonsoft.Json;

namespace pasaj.mvc.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            string serializedString = JsonConvert.SerializeObject(value);
            session.SetString(key, serializedString);

        }

        public static T? GetJson<T>(this ISession session, string key) where T : class, new()
        {
            var serialized = session.GetString(key);
            return string.IsNullOrEmpty(serialized) ? default(T) :
                                                      JsonConvert.DeserializeObject<T>(serialized);

        }
    }
}
