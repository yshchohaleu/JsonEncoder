using System;
using System.Linq;
using System.Reflection;
using JsonEncoder.Attributes;
using JsonEncoder.Converters;
using Newtonsoft.Json.Serialization;

namespace JsonEncoder.DataResolvers
{
    public class EncodeContractResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);

            foreach (var property in contract.Properties)
            {
                var member = objectType.GetTypeInfo().GetProperty(property.PropertyName);
                var encode = !member.GetCustomAttributes<JsonIgnoreEncodeAttribute>().Any();

                if (encode && member.PropertyType == typeof(String))
                {
                    property.MemberConverter = new EncodingConverter();
                }
            }

            return contract;
        }
    }
}
