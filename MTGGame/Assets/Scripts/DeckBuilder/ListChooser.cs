using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ListChooser : MonoBehaviour
{
    [System.NonSerialized]
    public string docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

    public string workingFile = "";

    public GameObject newListPanel;

    public TMP_InputField newName;

    public GameObject ButtonUI;

    public GameObject deckBuilder;

    public GameObject chooseList;

    public TMP_Dropdown list;

    public GameObject EditListPanel;

    private void Start()
    {
        list.ClearOptions();
        docs += @"\decks\";
        DirectoryInfo d = new DirectoryInfo(docs);
        List<string> options = new List<string>();
        foreach (var file in d.GetFiles("*.json"))
        {
            options.Add((file.Name.Split('.')[0]));
        }
        list.AddOptions(options);
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
