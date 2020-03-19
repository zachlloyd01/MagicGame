using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using System.Linq;
using System.Text.RegularExpressions;

public class DataFromJson : MonoBehaviour
{
    public TextAsset allCards; //JSON that contains all the MTG Cards ever created
    Regex reg = new Regex("[^a-zA-Z' ]"); //Get rid of all non-alphanumeric chars (except spaces)

    public void CreateJsonObjects() //Called on button from scene
    {
        StartCoroutine(JsonGenerate()); //Run seperately from main thread, can multitask this way
    }

    public void TestCardCreate()
    {
        StartCoroutine(CardGenerate());
    }

    private IEnumerator JsonGenerate() //Coroutine goodness
    {
        string json; //WIll be set to the full json data for each card
        using (StreamReader sr = new StreamReader(AssetDatabase.GetAssetPath(allCards))) //Read the file of the full JSON file
        {
            json = sr.ReadToEnd(); //Read through the entire file, set json to the string that is generated
            sr.Close(); //Close the reader
        } 

        dynamic data = JsonConvert.DeserializeObject(json); //Create the dict of values from the json string
        IDictionary<string, JToken> cards = data; //Explicitly set it as a dictionary

        foreach (var card in cards) //for every set of values in cards
        {
            CardData newCard = JsonConvert.DeserializeObject<CardData>(card.Value.ToString()); //Deserialize the card that the iteration counter is on
            JObject newCardJson = new JObject(); //A new JSON value set to store individual cards

            newCardJson.Add("name", newCard.name); //Add(valueName, value)
            newCardJson.Add("manacost", newCard.manaCost);
            newCardJson.Add("cmc", newCard.cmc);
            JArray colors = new JArray(); //Array of colors
            colors.Add(newCard.colors); //Add card colors to the array
            newCardJson.Add("colors", colors); //Add, but the new Array
            newCardJson.Add("type", newCard.type);
            JArray subtypes = new JArray();
            subtypes.Add(newCard.subTypes);
            newCardJson.Add("subtypes",subtypes);
            newCardJson.Add("text", newCard.text);
            newCardJson.Add("power", newCard.power);
            newCardJson.Add("toughness", newCard.toughness);
            newCardJson.Add("oracleid", newCard.oracleID);

            string cardName = reg.Replace(newCard.name, string.Empty); //Use the Regex from earlier to replace all non-alphanumeric chars
            File.WriteAllText($@"Assets/CardData/JsonObjects/{cardName}.json", JsonConvert.SerializeObject(newCardJson)); //Write the data to a new JSON file, that has the cardname as its file name
            break;
        }
        yield return null; //The coroutine just generates the JSON, does not need to return anything... maybe it should return true when it completes?
    }

    private IEnumerator CardGenerate()
    {
        GameObject newCard = new GameObject();
        newCard.AddComponent<SpriteRenderer>();
        yield return null;
    }
}
