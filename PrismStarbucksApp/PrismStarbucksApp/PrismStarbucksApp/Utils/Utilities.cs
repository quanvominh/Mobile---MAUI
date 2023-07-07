using System;
using System.Text;
using Newtonsoft.Json;

namespace PrismStarbucksApp.Utils
{
    public static class Utilities
    {
        public static StringContent ObjectToStringContent<T>(this T objectToSend)
        {
            var json = JsonConvert.SerializeObject(objectToSend, settings: new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }
    }
}

