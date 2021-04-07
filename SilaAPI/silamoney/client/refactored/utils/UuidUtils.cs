using System;

namespace SilaAPI.silamoney.client.refactored.utils
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