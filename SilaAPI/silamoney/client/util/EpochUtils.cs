using System;

namespace SilaAPI.silamoney.client.util
{
    /// <summary>
    /// Epoch utils class
    /// </summary>
    public static class EpochUtils
    {
        /// <summary>
        /// Generates the actual time in epoch format.
        /// </summary>
        /// <returns>int</returns>
        public static int getEpoch(){
            return ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds) - 100;
        }
    }
}