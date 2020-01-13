using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;

    private const string PlayerPrefsNameKey = "PlayerName"; //Key to retrieve and autofill the name field

    private void Start()
    {
        SetUpInputField();
    }

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) //If the key for the name is empty (No previous value stored)
        {
            return; 
        }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey); //the default value for the name value (assumes that there is a value in the key, otherwise will error to null

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
        continueButton.interactable = !string.IsNullOrEmpty(name); //Make the button interactable (don't want people entering the network with no nickname)
    }

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;

        PhotonNetwork.NickName = playerName; //The name of the client on the server

        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName); //Save the name to the playerprefs key
    }
}

