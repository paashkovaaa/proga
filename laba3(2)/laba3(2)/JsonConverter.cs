using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using laba3;
internal class JsonConverter
{
    public static string Serialize(Polynomial fraction)
    {
        return JsonConvert.SerializeObject(fraction);
    }
    public static Polynomial? Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<Polynomial>(json);
    }
}