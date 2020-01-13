using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class spawner : MonoBehaviour
{

    [SerializeField] private GameObject board;
    [SerializeField] private GameObject deck;
    [SerializeField] private GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        makeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void makeObjects()
    {
        board = PhotonNetwork.Instantiate(board.name, Vector3.zero, Quaternion.identity); //Put object onto the server at location
        board.name = $"{PhotonNetwork.NickName} - Board"; //Set object name
        deck = PhotonNetwork.Instantiate(deck.name, Vector3.zero, Quaternion.identity); //Put object onto the server at location
        deck.name = $"{PhotonNetwork.NickName} - Deck"; //Set object name
        deck.transform.parent = board.transform; //Parent is user's board state
        hand = PhotonNetwork.Instantiate(hand.name, Vector3.zero, Quaternion.identity); //Put object onto the server at location
        hand.name = $"{PhotonNetwork.NickName} - Hand"; //Set object name
        hand.transform.parent = board.transform; //parent is user's board state
    }
}
