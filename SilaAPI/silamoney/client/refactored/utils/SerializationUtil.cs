using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sila.API.Client.Utils
{
    /// <summary>
    /// Class used to convert from objects to string and vice versa.
    /// </summary>
    internal static class SerializationUtil
    {
        public static String Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj,
                Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    //ContractResolver = RemoveStringsImplementation.Instance,
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        public static String Serialize(Dictionary<string, object> obj)
        {
            return JsonConvert.SerializeObject(
                obj
                .Where(p => p.Value != null)
                .ToDictionary(p => p.Key, p => p.Value),
                Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        public static Object Deserialize(string obj)
        {
            return obj != null ? JsonConvert.DeserializeObject(obj) : null;
        }
    }
}
