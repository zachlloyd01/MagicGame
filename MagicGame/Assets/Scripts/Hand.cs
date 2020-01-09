using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public List<int> handList;

    private GameObject deck;

    public GameObject cardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        deck = GameObject.Find("Deck");
        handList = deck.GetComponent<DeckGenerate>().handList;
        for (int i = 0; i < handList.Count; i++)
        {
            cardGenerate card = generateCard();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
        cardPrefab = Instantiate(cardPrefab); //Instantiate into the scene
        cardPrefab.transform.parent = gameObject.transform;
        //Set the rest of the card values to their respective key pairs here (I will do this once we can search through)
    }
}
