using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public string[] orderTurn;


    private List<Photon.Realtime.Player> tempTurn;

    private void OnEnable()
    {
        orderTurn = new string[2];
        if (PhotonNetwork.IsMasterClient)
        {
            tempTurn = new List<Photon.Realtime.Player>(PhotonNetwork.PlayerList);
            tempTurn.Shuffle();
            for(int i = 0; i < tempTurn.Count; i++)
            {
                orderTurn[i] = tempTurn[i].NickName;
            }
            photonView.RPC("setTurnOrder", RpcTarget.OthersBuffered, orderTurn);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [PunRPC]
    void setTurnOrder(string[] localTurn)
    {
        Debug.Log("rpc");
        for(int i = 0; i < localTurn.Length; i++)
        {
            orderTurn[i] = localTurn[i];
        }
        Debug.Log(localTurn[0]);
    }

}