using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Board : MonoBehaviour
{
    public int health;
    public string owner;

    public GameObject deck;
    public GameObject hand;

    private 
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        makeStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increment (int amount)
    {
        health += amount;
    }

    private void makeStart()
    {
        deck = PhotonNetwork.Instantiate(deck.name, Vector3.zero, Quaternion.identity); //Put object onto the server at location
        deck.name = $"{PhotonNetwork.NickName} - Deck"; //Set object name
        deck.GetComponent<PhotonView>().TransferOwnership(gameObject.GetComponent<PhotonView>().Owner);
        deck.transform.parent = gameObject.transform; //Parent is user's board state
        hand = PhotonNetwork.Instantiate(hand.name, Vector3.zero, Quaternion.identity); //Put object onto the server at location
        hand.name = $"{PhotonNetwork.NickName} - Hand"; //Set object name
        hand.GetComponent<PhotonView>().TransferOwnership(gameObject.GetComponent<PhotonView>().Owner);
        
        hand.transform.parent = gameObject.transform; //parent is user's board state
    }
}
