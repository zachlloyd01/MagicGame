using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class DeckGenerate : MonoBehaviour
{
    public List<int> deckList;
    public TextAsset fileList;

    public GameObject cardPrefab;

    private Random rand = new Random();

    // Start is called before the first frame update
    void Start()
    {
        string[] fLines = Regex.Split(fileList.text, "\n|\r|\r\n");
        foreach (string card in fLines)
        {
            deckList.Add(int.Parse(card));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Used to add cards to hand
    private void OnMouseDown()
    {
        /*int choice = Random.Range(0, deckList.Count - 1);

        //Parse through the JSON array of cards by card # here, to get the key value, then set that value to the string cardName @Andrew
        string cardName = "";

        cardGenerate card = cardGenerate.CreateInstance(cardName) as cardGenerate; //Instance of the card
        cardPrefab.GetComponent<CardDisplay>().card = card; //set the values of the generated card
        cardPrefab = Instantiate(cardPrefab); //Instantiate into the scene
        
        //Set the rest of the card values to their respective key pairs here (I will do this once we can search through*/

        Debug.Log("object clicked big boy");
    }
}
