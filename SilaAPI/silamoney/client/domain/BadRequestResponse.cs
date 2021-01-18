using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class BadRequestResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("validation_details")]
        public JObject ValidationDetails { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AllValidationDetails
        {
            get
            {
                if (ValidationDetails != null && ValidationDetails.HasValues)
                {
                    return getJObjectProperties(ValidationDetails);
                }
                return null;
            }
        }

        private string getJObjectProperties(JObject node)
        {
            string message = "";
            foreach (var child in node.Properties())
            {
                if (child.HasValues)
                {
                    message += getJPropertyProperties(child);
                }
                else
                {
                    message += child.Name + ": " + child.Value.Value<string>() + Environment.NewLine;
                }
            }
            return message;
        }

        private string getJPropertyProperties(JProperty node)
        {
            string message = "";
            foreach (var child in node.Values())
            {
                if (child.HasValues)
                {
                    message += getJTokenProperties(child);
                }
                else
                {
                    message += child.Path + ": " + child.Value<string>() + Environment.NewLine;
                }
            }
            return message;
        }

        private string getJTokenProperties(JToken node)
        {
            string message = "";
            foreach (var child in node.Values())
            {
                if (child.HasValues)
                {
                    message += getJTokenProperties(child);
                }
                else
                {
                    message += child.Path + ": " + child.Value<string>() + Environment.NewLine;
                }
            }
            return message;
        }
    }
}
