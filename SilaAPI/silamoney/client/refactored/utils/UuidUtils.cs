using System;

namespace Sila.API.Client.Utils
{
    public static class UuidUtils
    {
        public static string GetUuid()
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }
    }
}