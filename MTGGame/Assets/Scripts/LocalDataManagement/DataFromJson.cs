using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

public class DataFromJson : MonoBehaviour
{
    public TextAsset allCards; //JSON that contains all the MTG Cards ever created
    Regex reg = new Regex("[^a-zA-Z' ]"); //Get rid of all non-alphanumeric chars (except spaces)

    public void CreateJsonObjects() //Called on button from scene
    {
        StartCoroutine(JsonGenerate()); //Run seperately from main thread, can multitask this way
    }

    private IEnumerator JsonGenerate() //Coroutine goodness
    {
        string json; //WIll be set to the full json data for each card
        using (StreamReader sr = new StreamReader(AssetDatabase.GetAssetPath(allCards))) //Read the file of the full JSON file
        {
            json = sr.ReadToEnd(); //Read through the entire file, set json to the string that is generated
            sr.Close(); //Close the reader
        } 

        dynamic data = JsonConvert.DeserializeObject(json); //Create the dict of JObjects from the json string

        foreach (JObject card in data)
        {
            CardData newCard = JsonConvert.DeserializeObject<CardData>(card.ToString()); //Deserialize the data into an instance of CardData
            string cardName = reg.Replace(newCard.name, string.Empty); //Use the Regex from earlier to replace all non-alphanumeric chars
            File.WriteAllText($@"Assets/Resources/JsonObjects/{cardName}.json", JsonConvert.SerializeObject(newCard)); //Write the data to a new JSON file, that has the cardname as its file name
        }
        yield return null; //The coroutine just generates the JSON, does not need to return anything... maybe it should return true when it completes?
    }
}
