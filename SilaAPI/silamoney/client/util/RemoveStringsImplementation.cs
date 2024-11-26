using System;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SilaAPI.silamoney.client.util
{
    #pragma warning disable CS1591
    public class RemoveStringsImplementation : DefaultContractResolver
    {
        public static readonly RemoveStringsImplementation Instance = new RemoveStringsImplementation();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType == typeof(string))
            {
                // Do not include emptry strings
                property.ShouldSerialize = instance =>
                {
                    return !string.IsNullOrWhiteSpace(instance.GetType().GetProperty(member.Name).GetValue(instance, null) as string);
                };
            }
            return property;
        }
    }
    #pragma warning restore CS1591
}