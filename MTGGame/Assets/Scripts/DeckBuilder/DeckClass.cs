using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class DeckClass
{
    [JsonProperty("names")]
    public List<string> names { get; set; }
}

