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

    public GameObject manager;

    int currentPlayer;

    private void Start()
    {
        PhotonNetwork.Instantiate(manager.name, Vector3.zero, Quaternion.identity);
        PhotonNetwork.AutomaticallySyncScene = true;

        this.gameObject.AddComponent<PhotonView>();
        List<Photon.Realtime.Player> turnOrder = new List<Photon.Realtime.Player>();
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            // turnOrder.Add(player);
            Players.Add(new GameObject());
            Players[Players.Count - 1].AddComponent<game_player>();
            Players[Players.Count - 1].name = player.NickName;
            orderTurns.Add(player.NickName);
        }
        if (PhotonNetwork.IsMasterClient) {
            orderTurns.Shuffle();
            // String.Join(",", orderTurns.ToArray()).ToString()
            this.photonView.RPC("getOrder", RpcTarget.All, orderTurns.ToArray()); // Send to other players
        }
        currentPlayer = 0;
    }

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
        SceneManager.LoadScene("MainMenu");
    }

    #endregion

    #region Default Functions

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf.Equals(false))
        {
            pausePanel.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf.Equals(true)) {
            pausePanel.SetActive(false);
        }
        if (orderTurns.Count > 0) {
          string values = "Order:\n";
          foreach (string x in orderTurns) {
              values += x + "\n";
          }
          centerText.SetText(values);
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

    [PunRPC]
    public void getOrder (string[] order) {
      if (!PhotonNetwork.IsMasterClient) {
        orderTurns = new List<string>();
        orderTurns.AddRange(order);
      }
    }

    #region Game Management

    #endregion
}
