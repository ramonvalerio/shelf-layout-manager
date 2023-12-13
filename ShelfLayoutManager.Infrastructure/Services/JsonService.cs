using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ShelfLayoutManager.Core.Domain.Shelves;
using System.Reflection;

namespace ShelfLayoutManager.Infrastructure.Services
{
    public class JsonService
    {
        public Shelf LoadDataFromJson()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "shelf.json");
            var jsonData = File.ReadAllText(filePath);

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateResolver()
            };

            return JsonConvert.DeserializeObject<Shelf>(jsonData);
        }

        private class PrivateResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                if (property.Writable) return property;

                PropertyInfo? prop = member as PropertyInfo;

                if (prop != null)
                {
                    bool hasPrivateSetter = prop.GetSetMethod(true) != null;
                    property.Writable = hasPrivateSetter;
                }

                return property;
            }
        }
    }
}