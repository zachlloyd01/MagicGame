﻿using Photon.Pun;
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

    public GameObject turnManager;
    public GameObject NewPlayer;
    int currentPlayer;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
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
