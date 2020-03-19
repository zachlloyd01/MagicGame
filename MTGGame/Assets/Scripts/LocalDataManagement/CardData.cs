using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData //The base layout for storing JSON Data
{
    // [JsonProperty("layout")]
    // public string layout { get; set; }

    [JsonProperty("name")] //The name of the variable in the full JSON Data file
    public string name { get; set; } //the new variable to store in the card data

    [JsonProperty("manaCost")]
    public string manaCost { get; set; }

    [JsonProperty("cmc")]
    public string cmc { get; set; }

    [JsonProperty("colors")]
    public string[] colors { get; set; }

    [JsonProperty("type")]
    public string type { get; set; }

    [JsonProperty("subtypes")]
    public string[] subTypes { get; set; }

    [JsonProperty("text")]
    public string text { get; set; }

    [JsonProperty("power")]
    public string power { get; set; }

    [JsonProperty("toughness")]
    public string toughness { get; set; }

    [JsonProperty("scryfallOracleId")]
    public string oracleID { get; set; }
}
