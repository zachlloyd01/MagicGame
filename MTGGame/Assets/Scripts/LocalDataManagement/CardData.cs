using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageUris
{
    public string small { get; set; }
    public string normal { get; set; }
    public string large { get; set; }
    public string png { get; set; }
    public string art_crop { get; set; }
    public string border_crop { get; set; }
}

public class Legalities
{
    public string standard { get; set; }
    public string future { get; set; }
    public string historic { get; set; }
    public string pioneer { get; set; }
    public string modern { get; set; }
    public string legacy { get; set; }
    public string pauper { get; set; }
    public string vintage { get; set; }
    public string penny { get; set; }
    public string commander { get; set; }
    public string brawl { get; set; }
    public string duel { get; set; }
    public string oldschool { get; set; }
}

public class RelatedUris
{
    public string tcgplayer_decks { get; set; }
    public string edhrec { get; set; }
    public string mtgtop8 { get; set; }
}

public class CardData
{
    public string @object { get; set; }
    [JsonProperty("id")]
    public string id { get; set; }
    [JsonProperty("oracle_id")]
    public string oracle_id { get; set; }
    [JsonProperty("multiverse_ids")]
    public List<object> multiverse_ids { get; set; }
    [JsonProperty("tcgplayer_id")]
    public int tcgplayer_id { get; set; }
    [JsonProperty("name")]
    public string name { get; set; }
    [JsonProperty("lang")]
    public string lang { get; set; }
    [JsonProperty("released_at")]
    public string released_at { get; set; }
    [JsonProperty("uri")]
    public string uri { get; set; }
    [JsonProperty("scryfall_uri")]
    public string scryfall_uri { get; set; }
    [JsonProperty("layout")]
    public string layout { get; set; }
   /* [JsonProperty("highres_img")]
    public bool highres_image { get; set; }*/
    [JsonProperty("image_uris")]
    public ImageUris image_uris { get; set; }
    [JsonProperty("mana_cost")]
    public string mana_cost { get; set; }
    [JsonProperty("cmc")]
    public double cmc { get; set; }
    [JsonProperty("type_line")]
    public string type_line { get; set; }
    [JsonProperty("oracle_text")]
    public string oracle_text { get; set; }
    [JsonProperty("colors")]
    public List<string> colors { get; set; }
    [JsonProperty("color_identity")]
    public List<string> color_identity { get; set; }
    [JsonProperty("legalities")]
    public Legalities legalities { get; set; }
    [JsonProperty("games")]
    public List<object> games { get; set; }
/*    [JsonProperty("reserved")]
    public bool reserved { get; set; }
    [JsonProperty("foil")]
    public bool foil { get; set; }
    [JsonProperty("nonfoil")]
    public bool nonfoil { get; set; }
    [JsonProperty("oversized")]
    public bool oversized { get; set; }
    [JsonProperty("promo")]
    public bool promo { get; set; }
    [JsonProperty("reprint")]
    public bool reprint { get; set; }
    [JsonProperty("variation")]
    public bool variation { get; set; }*/
    [JsonProperty("set")]
    public string set { get; set; }
    [JsonProperty("set_name")]
    public string set_Name { get; set; }
    [JsonProperty("set_type")]
    public string set_type { get; set; }
    [JsonProperty("set_uri")]
    public string set_Uri { get; set; }
    [JsonProperty("set_search_uri")]
    public string set_search_uri { get; set; }
    [JsonProperty("scryfall_set_uri")]
    public string scryfall_set_uri { get; set; }
    [JsonProperty("rulings_uri")]
    public string rulings_uri { get; set; }
    [JsonProperty("prints_search_uri")]
    public string prints_search_uri { get; set; }
    /*[JsonProperty("collector_number")]
    public string collector_number { get; set; }*/
/*    [JsonProperty("collector_number")]
    public bool digital { get; set; }*/
    [JsonProperty("rarity")]
    public string rarity { get; set; }
    [JsonProperty("card_back_id")]
    public string card_back_id { get; set; }
    [JsonProperty("artist")]
    public string artist { get; set; }
    [JsonProperty("artist_ids")]
    public List<string> artist_ids { get; set; }
    [JsonProperty("illustration_id")]
    public string illustration_id { get; set; }
    [JsonProperty("border_color")]
    public string border_color { get; set; }
    [JsonProperty("frame")]
    public string frame { get; set; }
/*    [JsonProperty("full_art")]
    public bool full_art { get; set; }
    [JsonProperty("textless")]
    public bool textless { get; set; }
    [JsonProperty("booster")]
    public bool booster { get; set; }*/
    /*[JsonProperty("story_spotlight")]
    public bool story_spotlight { get; set; }*/
    [JsonProperty("edhrec_rank")]
    public int edhrec_rank { get; set; }
    [JsonProperty("related_uris")]
    public RelatedUris related_uris { get; set; }
}