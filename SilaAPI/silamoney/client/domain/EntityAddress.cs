using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Address object used in the entity_msg object
    /// </summary>
    [DataContract]
    public partial class EntityAddress : Address
    {
    }
}
