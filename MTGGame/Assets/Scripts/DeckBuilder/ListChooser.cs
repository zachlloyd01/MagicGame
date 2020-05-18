using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ListChooser : MonoBehaviour
{

    #region Public Variables

    [System.NonSerialized]
    public string docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments); //Get User Docs folder

    public string workingFile; //File to edit

    public GameObject newListPanel; //New Panel

    public TMP_InputField newName; //New Deck Name

    public GameObject ButtonUI; //Main Menu

    public GameObject deckBuilder; //Deckbuilder UI

    public GameObject chooseList; //List choosing UI

    public TMP_Dropdown list; //List chooser dropdown

    public GameObject EditListPanel; //List Editor Chooser UI

    #endregion

    private void Start()
    {
        if(!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\decks\")) { //If the decks dir does not exist
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\decks\"); //Create the decks dir
        }
        list.ClearOptions(); //Clear the Dropdown options
        docs += @"\decks\"; //Append the decks folder to docs
        DirectoryInfo d = new DirectoryInfo(docs); //Get the files in the decks dir
        List<string> options = new List<string>(); //Will be all files in the decks dir
        foreach (var file in d.GetFiles("*.json")) //Every json file in decks dir
        {
            options.Add((file.Name.Split('.')[0]));  //Append the file name to the list
        }
        list.AddOptions(options); //Set the dropdown options to the list
        ButtonUI.SetActive(true); //Set mainmenu active
        newListPanel.SetActive(false); //Turn off the new panel
    }

    
    public void newList()
    {
        newListPanel.SetActive(true);
        ButtonUI.SetActive(false);
    }

    public void editList()
    {
        ButtonUI.SetActive(false);
        EditListPanel.SetActive(true);
    }

    public void createNewList()
    {
        newListPanel.SetActive(true);
        ButtonUI.SetActive(false);
    }

    public void setNew()
    {
        workingFile = docs + newName.text + ".json";
        if(!File.Exists(workingFile))
        {
            File.Create(workingFile);
        }
        chooseList.SetActive(false);
        deckBuilder.SetActive(true);
    }

    public void editListSubmit()
    {
        workingFile = docs + list.captionText.text + ".json";
        EditListPanel.SetActive(false);
        deckBuilder.SetActive(true);
    }
}
