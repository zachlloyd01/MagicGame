using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class DeckClass
{
    [JsonProperty("ids")]
    public List<string> ids { get; set; }
}

