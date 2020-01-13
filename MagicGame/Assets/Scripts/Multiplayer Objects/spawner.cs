﻿using System.Collections;
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
        board.GetComponent<Board>().owner = PhotonNetwork.NickName;
        board = PhotonNetwork.Instantiate(board.name, Vector3.zero, Quaternion.identity); //Put object onto the server at location
        board.name = $"{PhotonNetwork.NickName} - Board"; //Set object name
    }
}
