using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

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
            StringBuilder message = new StringBuilder();
            foreach (var child in node.Properties())
            {
                if (child.HasValues)
                {
                    message.Append(getJPropertyProperties(child));
                }
                else
                {
                    message.Append(child.Name + ": " + child.Value.Value<string>());
                }
            }
            return message.ToString();
        }

        private StringBuilder getJPropertyProperties(JProperty node)
        {
            StringBuilder message = new StringBuilder();
            foreach (var child in node.Values())
            {
                if (child.HasValues)
                {
                    message.Append(getJTokenProperties(child));
                }
                else
                {
                    message.Append(child.Path + ": " + child.Value<string>());
                }
            }
            return message;
        }

        private StringBuilder getJTokenProperties(JToken node)
        {
            StringBuilder message = new StringBuilder();
            foreach (var child in node.Values())
            {
                if (child.HasValues)
                {
                    message.Append(getJTokenProperties(child));
                }
                else
                {
                    message.Append(child.Path + ": " + child.Value<string>());
                }
            }
            return message;
        }
    }
}
