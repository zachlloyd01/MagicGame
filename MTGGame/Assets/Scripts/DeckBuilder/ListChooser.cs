using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListChooser : MonoBehaviour
{
    public string docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

    public static string workingFile = "";

    public GameObject newListPanel;

    public TMP_InputField newName;

    public GameObject ButtonUI;

    public GameObject deckBuilder;

    public GameObject chooseList;
    private void Start()
    {
        ButtonUI.SetActive(true);
        newListPanel.SetActive(false);   
    }
    public void newList()
    {
        newListPanel.SetActive(true);
        ButtonUI.SetActive(false);
    }

    public void editList()
    {

    }

    public void createNewList()
    {
        newListPanel.SetActive(true);
        ButtonUI.SetActive(false);
    }

    public void setNew()
    {
        workingFile = docs + newName.text + ".json";
        chooseList.SetActive(false);
        deckBuilder.SetActive(true);
    }
}
