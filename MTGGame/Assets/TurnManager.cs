using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public string values;

    public List<GameObject> Players;
    public List<string> orderTurn;
    new PhotonView photonView;

    int currentPlayer;

    public override void OnEnable()
    {
        photonView = GetComponent<PhotonView>();
        List<Photon.Realtime.Player> turnOrder = new List<Photon.Realtime.Player>();
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            // turnOrder.Add(player);
            Players.Add(new GameObject());
            Players[Players.Count - 1].AddComponent<game_player>();
            Players[Players.Count - 1].name = player.NickName;
            orderTurn.Add(player.NickName);
        }
        if (PhotonNetwork.IsMasterClient)
        {
            orderTurn.Shuffle();
            // String.Join(",", orderTurns.ToArray()).ToString()
            photonView.RPC("getOrder", RpcTarget.All, orderTurn.ToArray()); // Send to other players
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
        if (orderTurn.Count > 0)
        {
            string values = "Order:\n";
            foreach (string x in orderTurn)
            {
                values += x + "\n";
            }
        }
    }

    [PunRPC]
    public void getOrder(string[] order)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            orderTurn = new List<string>();
            orderTurn.AddRange(order);
        }
    }
}