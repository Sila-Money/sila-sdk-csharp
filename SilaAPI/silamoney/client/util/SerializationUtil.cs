using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.util
{
    public class SerializationUtil
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
