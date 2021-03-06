﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using TMPro;
using System.IO;
using Newtonsoft.Json;

public class Launcher : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields
    /// <summary>
    /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
    /// </summary>
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject controlPanel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    private TMP_Text progressLabel;

    #endregion

    #region Public Fields

    [System.NonSerialized]
    public string docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

    public TMP_Dropdown list;

    private GameObject deckList;

    #endregion

    #region Private Fields


    /// <summary>
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// </summary>
    string gameVersion = "1";
    bool isConnecting;

    #endregion


    #region MonoBehaviour CallBacks


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        deckList = new GameObject();
        deckList.name = "deckList";
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
        DontDestroyOnLoad(deckList);
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        list.ClearOptions();
        docs += @"\decks\";
        DirectoryInfo d = new DirectoryInfo(docs);
        List<string> options = new List<string>();
        foreach (var file in d.GetFiles("*.json"))
        {
            options.Add((file.Name.Split('.')[0]));
        }
        list.AddOptions(options);
        progressLabel.SetText(""); // SetActive(false)
        controlPanel.SetActive(true);

        deckList.AddComponent<deckListHolder>();
        // Connect();
        DontDestroyOnLoad(deckList);
    }

    void Update () {
      if (PhotonNetwork.PlayerList.Length > 0) { // is connected
        progressLabel.SetText(getStatus());
      }
    }


    #endregion


    #region Public Methods


    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    ///


    public void buttonConnect()
    {
        string json;
        using(StreamReader sr = new StreamReader(docs + list.captionText.text + ".json"))
        {
            json = sr.ReadToEnd();
            sr.Close();
        }
        DeckClass deck = JsonConvert.DeserializeObject<DeckClass>(json);
        deckList.GetComponent<deckListHolder>().deckClass = deck;
        DontDestroyOnLoad(deckList);
        Connect();
    }


    public void Connect()
    {
        controlPanel.SetActive(false);
        progressLabel.SetText("Connecting..."); // SetActive(true)
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }


    public string getStatus () { // returns status of lobby + info
      string status = PhotonNetwork.CurrentRoom.PlayerCount + "/" + maxPlayersPerRoom + "\n";
      foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList) {
        status += player.NickName + "\n";
      }
      return status;
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks


    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");

        // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }

    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        progressLabel.SetText(""); // SetActive(false)
        controlPanel.SetActive(true);
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        // Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        if (PhotonNetwork.CurrentRoom.PlayerCount >= maxPlayersPerRoom)
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= maxPlayersPerRoom)
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }

    #endregion
}
