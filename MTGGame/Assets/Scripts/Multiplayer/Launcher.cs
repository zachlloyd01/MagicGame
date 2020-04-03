using System.Collections;
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
    #region private serializable fields

    [Tooltip("UI Panel for username creation, and connecting")]
    [SerializeField]
    private GameObject controlPanel;

    [Tooltip("UI Label for connection information")]
    [SerializeField]
    private GameObject progressLabel;

    [Tooltip("Dropdown of Deck Files in the decks folder in Documents")]
    [SerializeField]
    private TMP_Dropdown list;

    #endregion

    #region Private fields

    private string gameVersion = "0.1"; //Game Version... duh
    private bool isConnecting; //keep track of current progress
    private string docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    private GameObject deckHolder;

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
        deckHolder = new GameObject();
        docs += @"\decks\";
        DirectoryInfo d = new DirectoryInfo(docs);
        List<string> options = new List<string>();
        foreach (var file in d.GetFiles("*.json"))
        {
            options.Add((file.Name.Split('.')[0]));
        }
        list.AddOptions(options);
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
/*        deckHolder = Instantiate(deckHolder);
        deckListHolder listHolder = deckHolder.AddComponent<deckListHolder>();
        
        string file = docs + list.captionText.text + ".json";
        string json;
        using (StreamReader sr = new StreamReader(file)) 
        {
            json = sr.ReadToEnd();
            sr.Close();
        }*/
        // DeckClass deckClass = JsonConvert.DeserializeObject<DeckClass>(json);
        // listHolder.deckClass = deckClass;
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
            // DontDestroyOnLoad(deckHolder);
            PhotonNetwork.LoadLevel("Game");
        }
    }

    #endregion
}
