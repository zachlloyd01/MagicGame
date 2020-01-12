using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private Button continueButton;

    private const string PlayerPrefsNameKey = "PlayerName";

    private void Start()
    {
        //continueButton.interactable = !string.IsNullOrEmpty(nameInputField.text);
        SetUpInputField();
    }

    private void SetUpInputField()
    {
        if(!PlayerPrefs.HasKey(PlayerPrefsNameKey))
        {
            return;
        }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }

    public void SetPlayerName (string name)
    {
       // continueButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;

        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
    }
}
