using Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using System;


public class Turns : MonoBehaviourPun
{
    public List<string> orderTurns;
    public TMP_Text centerText;
    void Start()
    {
      if(PhotonNetwork.IsMasterClient)
      {
          PhotonNetwork.AutomaticallySyncScene = true;
          foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
          {
              orderTurns.Add(player.NickName);
          }
          orderTurns.Shuffle();
          //Debug.Log(orderTurns.ToArray());
          //photonView.RPC("SetTurns", RpcTarget.All, orderTurns.ToArray());
          //PhotonView photonView = PhotonView.Get(this);
          // PhotonView photonView = PhotonView.Get(this);
          this.photonView.RPC("ChatMessage", RpcTarget.All, "jup", "and jup.");
      }
    }

    string listTurns (string[] input) {
      string temp = null;
      foreach (string x in input) {
        temp += x + "\n";
      }
      return temp;
    }

    // Update is called once per frame
    void Update()
    {
      if (orderTurns.Count != 0) {
        centerText.SetText(listTurns(orderTurns.ToArray()));
      }
    }

    /*[PunRPC]
    public void SetTurns(string[] input){
      orderTurns = new List<string>();
      foreach (string x in input) {
        orderTurns.Add(x);
      }
      Debug.Log("Turns set!");
    }*/

    [PunRPC]
    void ChatMessage(string a, string b)
    {
      Debug.Log(string.Format("ChatMessage {0} {1}", a, b));
    }
}
