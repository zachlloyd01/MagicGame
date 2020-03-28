using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilderStart : MonoBehaviour
{
    public GameObject cardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach(CardData card in GameObject.FindGameObjectWithTag("Finish").GetComponent<ListStorage>().cards)
        {
            Instantiate(cardPrefab);
            cardPrefab.GetComponent<Builder_Card>().SetValues(JsonConvert.SerializeObject(card));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
