﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public string values;

    public List<GameObject> Players;
    public List<string> orderTurn;

    int currentPlayer;

    public override void OnEnable()
    {
        List<Photon.Realtime.Player> turnOrder = new List<Photon.Realtime.Player>();
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            orderTurn.Add(player.NickName);
        }
        if(PhotonNetwork.IsMasterClient)
        {
            orderTurn.Shuffle();
        }
        if (!PhotonNetwork.IsMasterClient)
        {
            orderTurn = new List<string>();
            orderTurn.AddRange(orderTurn.ToArray());
        }
        foreach (string x in orderTurn)
        {
            values += x;
        }
        
        currentPlayer = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}