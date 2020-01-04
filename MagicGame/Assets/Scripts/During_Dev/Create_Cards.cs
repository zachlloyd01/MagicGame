using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Create_Cards : MonoBehaviour
{

    public GameObject cardPrefab; //The prefab to create instances from

    // Start is called before the first frame update
    void Start()
    {
        createobjects();
    }

    private void createobjects()
    {
        string json = File.ReadAllText("cardlist.json"); //The file to read the data off of
        var jsonCards = JsonConvert.DeserializeObject<List<cardList>>(json); //deserialize the data into a readable list format
        foreach (cardList card in jsonCards)
        {
            Card i = Card.CreateInstance(card.name, card.type, card.description, int.Parse(card.attack), int.Parse(card.damage)); //Use the custom constructor to create a Card
            GameObject instance = GameObject.Instantiate(cardPrefab) as GameObject; //Get an instance of the prefab template
            instance.name = i.name; //set the name of the instance to the card name
            instance.GetComponent<CardDisplay>().card = i; //set the card data of the new prefab to the new card
            PrefabUtility.SaveAsPrefabAsset(instance, "/Cards/"); //save the new card prefab to the cards directory
        }
    }
}

public class cardList //The class to attach json data to
{
    public string name;
    public string type;
    public string attack;
    public string damage;
    public string flavorText;
    public string description;
}