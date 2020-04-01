using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class deck : MonoBehaviour, IPointerClickHandler
{

    public List<string> cards;

    public GameObject cardPrefab;

    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        newServerCard(cards[0]);
        cards.RemoveAt(cards.IndexOf(cards[0]));
    }

    private void newServerCard(string card)
    {
        temp = PhotonNetwork.Instantiate(this.cardPrefab.name, new Vector3(0, 0, 0), Quaternion.identity);
        temp.GetComponent<Play_Card>().id = card;
    }
}
