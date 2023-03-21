using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using laba3;
static class JsonConverter
{
    public static string Serialize(Polynomial polynomial)
    {
        return JsonConvert.SerializeObject(polynomial);
    }
    public static Polynomial? Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<Polynomial>(json);
    }
}