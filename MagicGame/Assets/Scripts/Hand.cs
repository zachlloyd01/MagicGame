using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public List<int> handList;

    private GameObject deck;
    // Start is called before the first frame update
    void Start()
    {
        deck = GameObject.Find("Deck");
        handList = deck.GetComponent<DeckGenerate>().handList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
