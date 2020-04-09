using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public List<Photon.Realtime.Player> orderTurn;

    private List<Photon.Realtime.Player> tempTurn;

    private void OnEnable()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            tempTurn = new List<Photon.Realtime.Player>(PhotonNetwork.PlayerList);
            tempTurn.Shuffle();
            orderTurn = tempTurn;
            photonView.RPC("setTurnOrder", RpcTarget.OthersBuffered, orderTurn.ToArray());
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
    void setTurnOrder(Photon.Realtime.Player[] localTurn)
    {
        Debug.Log("rpc");
        orderTurn = new List<Photon.Realtime.Player>(localTurn);
        Debug.Log(orderTurn[0]);
    }

}