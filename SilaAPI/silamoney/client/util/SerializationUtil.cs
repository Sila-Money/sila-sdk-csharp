using Newtonsoft.Json;
using System;

namespace SilaAPI.silamoney.client.util
{
    /// <summary>
    /// Class used to convert from objects to string and vice versa.
    /// </summary>
    internal static class SerializationUtil
    {
        public static String Serialize(object obj)
        {
            return obj != null ? JsonConvert.SerializeObject(obj) : null;
        }

        public static Object Deserialize(string obj)
        {
            return obj != null ? JsonConvert.DeserializeObject(obj) : null;
        }
    }
}
