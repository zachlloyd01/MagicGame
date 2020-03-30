﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(TMP_InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    #region private constants

    const string playerNamePrefKey = "PlayerName";

    #endregion

    #region Default Functions
    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty; //Default name is empty
        TMP_InputField inputField = this.GetComponent<TMP_InputField>(); 
        if(inputField != null)
        {
            if(PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey); //Set new default name
                inputField.text = defaultName;
            }
        }
        PhotonNetwork.NickName = defaultName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Public Methods

    public void SetPlayerName(string value)
    {
        if(string.IsNullOrEmpty(value))
        {
            Debug.Log("PLayer name is empty");
            return;
        }
        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(playerNamePrefKey, value);
    }

    #endregion
}
