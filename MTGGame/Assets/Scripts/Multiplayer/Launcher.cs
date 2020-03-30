using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Launcher : MonoBehaviourPunCallbacks
{
    #region private serializable fields

    [Tooltip("UI Panel for username creation, and connecting")]
    [SerializeField]
    private GameObject controlPanel;

    [Tooltip("UI Label for connection information")]
    [SerializeField]
    private GameObject progressLabel;

    #endregion

    #region Private fields

    private string gameVersion = "0.1"; //Game Version... duh
    private bool isConnecting; //keep track of current progress

    #endregion

    #region public fields

    [Tooltip("Max Players per game. If met, new players will be dumped into a new room.")]
    public byte maxPlayersPerRoom = 4;

    #endregion

    #region default functions

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Public Methods

    /* Start the Connection Process
     * If already connected, join a random room *
     * If not connected, connect instance to Photon Cloud */
     
    public void Connect()
    {
        isConnecting = PhotonNetwork.ConnectUsingSettings();
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom(); //If this fails, it will invoke the OnJoinRandomFailed() method
        }

        else
        {
            PhotonNetwork.ConnectUsingSettings(); //Connect to Photon Network
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    #endregion

    #region PUN Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectedToMaster()");
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom(); //Join room once reconnected to internet; if fails will invoke OnJinRandomRoomFailed()
            isConnecting = false;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        Debug.LogWarning($"OnDisconnected() was called with reason: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed(). No random room available. One will be made.");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom(). Client in a room.");
        if(PhotonNetwork.CurrentRoom.PlayerCount == maxPlayersPerRoom)
        {
            Debug.Log("Ready to Play");

            PhotonNetwork.LoadLevel("Game");
        }
    }

    #endregion
}
