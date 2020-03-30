using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Launcher : MonoBehaviourPunCallbacks
{
    #region private serializable fields

    [Tooltip("Max Players per game. If met, new players will be dumped into a new room.")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    #endregion

    #region Private fields

    private string gameVersion = "0.1"; //Game Version... duh

    #endregion

    #region default functions

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Connect();
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
        PhotonNetwork.JoinRandomRoom(); //Join room once reconnected to internet; if fails will invoke OnJinRandomRoomFailed()
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
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
    }

    #endregion
}
