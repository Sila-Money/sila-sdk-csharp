using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.util
{
    internal class UrlParamsUtilities
    {
        internal static string AddQueryParameter(string queryParameters, string parameterName, string value)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(queryParameters))
                {
                    queryParameters = "?";
                }
                else
                {
                    queryParameters += "&";
                }
                queryParameters += $"{parameterName}={value}";
                return queryParameters;
            }
            return "";
        }
    }
}
