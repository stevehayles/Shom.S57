using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace S57
{
    public class S57ExpectedInput
    {
        [JsonProperty("Code")]
        public uint Code { get; private set; }

        [JsonProperty("ID")]
        public uint Id { get; private set; }

        [JsonProperty("Meaning")]
        public string Meaning { get; private set; }
    }

    public class S57ExpectedInputs
    {
        public static List<S57ExpectedInput> ExpectedInputs => _expectedInputs.Value;

        private static Lazy<List<S57ExpectedInput>> _expectedInputs = new Lazy<List<S57ExpectedInput>>(() =>
        {
            var assembly = typeof(S57ExpectedInput).GetTypeInfo().Assembly;

            using (var stream = assembly.GetManifestResourceStream("Shom.s57.s57expectedinput.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<List<S57ExpectedInput>>(reader.ReadToEnd());
                }
            }
        });

        public static string GetMeaning(uint code, uint id)
        {
            return _expectedInputs.Value
                .Where(i => i.Code == code && i.Id == id)
                .Select(i => i.Meaning)
                .SingleOrDefault();
        }
    }
}
