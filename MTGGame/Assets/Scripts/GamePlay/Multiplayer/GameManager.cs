using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using System;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject pausePanel;
    public List<GameObject> Players;
    public List<string> orderTurns;
    public TMP_Text centerText;

    public string values;

    public List<string> orderTurn;


    public GameObject turnManager;
    public GameObject NewPlayer;
    int currentPlayer;

    #region Photon Callbacks

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
    {
        Debug.Log($"OnPlayerEnteredRoom(): {other.NickName}");

        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log($"OnPlayerEnteredRoom() IsMasterClient: {PhotonNetwork.IsMasterClient}");

            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        Debug.Log($"OnPlayerLeftRoom(): {other.NickName}");
    }

    public override void OnLeftRoom()
    {
        orderTurn.Clear();
        // GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().orderTurn = new string[2];
        SceneManager.LoadScene("MainMenu");
    }

    #endregion

    #region Default Functions

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                GameObject newPlayer = Instantiate(NewPlayer, Vector3.zero, Quaternion.identity);
                newPlayer.name = player.NickName;
            }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf.Equals(false))
        {
            pausePanel.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf.Equals(true)) {
            pausePanel.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("TurnManager") != null && centerText.text == "NULL")
        {
            centerText.text = "";
            foreach(string person in GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().orderTurn)
            {
                centerText.text += person + "\n";
            }
        }
        try
        {
            Debug.Log(GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().orderTurn[0]);
        }
        catch
        {
            Debug.Log("Got to the catch");
        }
        
    }
    

    #endregion

    #region Public Methods

    public void LeaveRoom()
    {

        pausePanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }

    #endregion

    #region Private Methods

    private void LoadArena()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("Photon Network: Trying to load level, but is not Master Client");
        }
        Debug.Log($"PhotonNetwork: Loading Level, with {PhotonNetwork.CurrentRoom.PlayerCount}");
        PhotonNetwork.LoadLevel("Game");
    }

    #endregion

    #region Game Management

    #endregion
}
