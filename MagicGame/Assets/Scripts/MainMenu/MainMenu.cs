using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject findOpponentPanel;
    [SerializeField] private GameObject waitingStatusPanel;
    [SerializeField] private Text waitingStatusText;

    private bool isConnecting = false;

    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 20;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void FindOpponent()
    {
        isConnecting = true;

        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);

        waitingStatusText.text = "Searching for opponents...";

        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {

        Debug.Log("Connected to Master");
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }

    }

    public override void OnDisconnect(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);

        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomRoomFailed(short returnCode, string message)
    {
        Debug.Log("No Clients are waiting for an opponent, creating new room...");

        PhotonNetwork.CreateRoom(null, new RoomOptions
        {
            MaxPlayersPerRoom = MaxPlayersPerRoom
        });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Client Successfully joined a room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if(playerCount < MaxPlayersPerRoom)
        {
            waitingStatusText.text = "Waiting for an opponent";
            Debug.Log("Client Waiting for opponent");
        }
        else
        {
            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentROom.IsOpen = false;
            Debug.Log("Match is ready to begin");
            waitingStatusText.text = "Opponent FOund";

            PhotonNetwork.LoadLevel("Scene_Main");
        }
    }
}
