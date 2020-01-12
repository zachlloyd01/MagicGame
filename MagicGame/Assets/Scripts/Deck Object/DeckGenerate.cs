using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using System.Linq;

public class DeckGenerate : MonoBehaviour
{
    public List<int> deckList;
    public TextAsset fileList;

    public GameObject cardPrefab;


    private static System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        createList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Used to add cards to hand
    private void OnMouseDown()
    {
        cardGenerate card = generateCard();
        
        cardSet(card);
        removeFromList(deckList.Count - 1);
        

    }

    private cardGenerate generateCard()
    {
        //Parse through the JSON array of cards by card # here, to get the key value, then set that value to the string cardName @Andrew
        string cardName = "";
        cardGenerate card = cardGenerate.CreateInstance(cardName) as cardGenerate; //Instance of the card
        return card;
    }

    private void cardSet(cardGenerate card)
    {
        cardPrefab.GetComponent<CardDisplay>().card = card; //set the values of the generated card
        //Set the rest of the card values to their respective key pairs here (I will do this once we can search through)
    }

    private void removeFromList(int choice)
    {
        deckList.Remove(deckList[choice]);
    }

    private void createList ()
    {
        string[] fLines = Regex.Split(fileList.text, "\n|\r|\r\n");
        foreach (string card in fLines)
        {
            deckList.Add(int.Parse(card));
        }
        deckList.Shuffle();
    }

}