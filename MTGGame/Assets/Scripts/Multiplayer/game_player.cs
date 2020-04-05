using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_player : MonoBehaviour
{
    public GameObject deck;

    public GameObject cardPrefab;

    private GameObject tempCard;

    private List<string> deckData;

    public DeckClass deckClass;

    // Start is called before the first frame update
    void OnEnable()
    {
        deckClass = GameObject.Find("deckList").GetComponent<deckListHolder>().deckClass;
        deckData = deckClass.ids;
        deckData.Shuffle();
        deck = Instantiate(deck);
        deck.transform.parent = GameObject.Find("Game").transform;
        deck.GetComponent<deck>().cards = deckData;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
