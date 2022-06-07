using System;

namespace Sila.API.Client.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class UuidUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetUuid()
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }
    }
}