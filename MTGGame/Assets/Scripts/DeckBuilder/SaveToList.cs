using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.IO;

public class SaveToList : MonoBehaviour
{
    #region Public Variables

    public TMP_InputField quantity; //How many cards to have
    public string cardName; //Card to add
    public string id; //Get the card's ID
    public GameObject newPanel; //Panel to open
    public TMP_Text title; //Title of the panel

    #endregion

    public void openPanel()
    {
        title.text = cardName;
        newPanel.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && newPanel.activeSelf)
        {
            newPanel.SetActive(false);
        }
    }

    #region Private Functions
    private void save()
    {
        int number = int.Parse(quantity.text); //How many times to add card
        appendList(id, number); //Add card to the WOrking File
    }



    private void appendList(string ID, int number) //Called from save()
    {
        string file = GetComponent<ListChooser>().workingFile; //Get the workingfile

        if (new FileInfo(file).Exists) //If the file exists
        {
            if (new FileInfo(file).Length > 0) //If the file already has data
            {
                string json; //WIll be set to the full json data for each card
                using (StreamReader sr = new StreamReader(file)) //Read the file of the full JSON file
                {
                    json = sr.ReadToEnd(); //Read through the entire file, set json to the string that is generated
                    sr.Close(); //Close the reader
                }
                DeckClass deck = JsonConvert.DeserializeObject<DeckClass>(json); //Generate a new DeckClass() from the file
                for (int i = 0; i < int.Parse(quantity.text); i++) //Amount of times to add card
                {
                    deck.ids.Add(ID); //Add the card to DeckClass()
                }
                string newData = JsonConvert.SerializeObject(deck); //Reserialize the DeckClass() instance
                File.WriteAllText(file, newData); //Write the json to the file
                newPanel.SetActive(false); //TUrn off add panel
            }

            else
            {
                DeckClass deck = new DeckClass(); //Create a new DeckClass()
                deck.ids = new List<string>(); //Empty list of IDs
                for (int i = 0; i < int.Parse(quantity.text); i++) //Amount of times to add the card
                {
                    deck.ids.Add(ID); //Add the card ID to the deck
                }
                string newData = JsonConvert.SerializeObject(deck); //Serialize the deck
                using (StreamWriter sw = File.CreateText(file)) //Write the text
                {
                    sw.WriteLine(newData);
                    sw.Close();
                }
                newPanel.SetActive(false); //Turn off add panel
            }
        }

        else
        {
            DeckClass deck = new DeckClass(); //Create a new DeckClass()
            deck.ids = new List<string>(); //Empty list of IDs
            for (int i = 0; i < int.Parse(quantity.text); i++) //Amount of times to add the card
            {
                deck.ids.Add(ID); //Add the card ID to the deck
            }
            string newData = JsonConvert.SerializeObject(deck); //Serialize the deck
            using (StreamWriter sw = File.CreateText(file)) //Write the text
            {
                sw.WriteLine(newData);
                sw.Close();
            }
            newPanel.SetActive(false); //Turn off add panel
        }


    }

    #endregion
}
