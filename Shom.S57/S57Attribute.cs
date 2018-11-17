using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace S57
{
    public class S57Attribute
    {
        public S57Attribute(uint code, string acronym, string name )
        {
            Name = name;
            Acronym = acronym;
            Code = code;
        }

        [JsonProperty("Attribute")]
        public string Name { get; private set; }

        [JsonProperty("Acronym")]
        public string Acronym { get; private set; }

        [JsonProperty("Code")]
        public uint Code { get; private set; }

        [JsonProperty("Attributetype")]
        public string AttributeType { get; private set; }

        [JsonProperty("Class")]
        public string Class { get; private set; }

        public override string ToString()
        {
            return $"{Name}: ({Acronym})";
        }
    }

    public static class S57Attributes
    {
        public static List<S57Attribute> Attributes => _attributes.Value;

        private static Lazy<List<S57Attribute>> _attributes = new Lazy<List<S57Attribute>>(() =>
        {
            var assembly = typeof(S57Objects).GetTypeInfo().Assembly;

            using (var stream = assembly.GetManifestResourceStream("Shom.s57.s57attributes.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<List<S57Attribute>>(reader.ReadToEnd());
                }
            }
        });

        public static S57Attribute Get(uint code)
        {
            return _attributes.Value.Where(attr => attr.Code == code).SingleOrDefault();
        }

        public static S57Attribute Get(string acronym)
        {
            return _attributes.Value.Where(attr => attr.Acronym.Equals(acronym)).SingleOrDefault();
        }
    }
}
