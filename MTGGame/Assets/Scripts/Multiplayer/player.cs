using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject deck;

    public GameObject cardPrefab;

    private GameObject tempCard;

    private List<string> deckData;

    public DeckClass deckClass;

    // Start is called before the first frame update
    void OnEnable()
    {
        deckClass = GameObject.Find("").GetComponent<deckListHolder>().deckClass;
        deckData = deckClass.ids;
        deckData.Shuffle();
        deck = Instantiate(deck);
        deck.transform.parent = GameObject.Find("Canvas").transform;
        deck.GetComponent<deck>().cards = deckData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
