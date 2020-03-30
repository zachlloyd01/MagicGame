using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

public class SaveToList : MonoBehaviour
{

    public TMP_InputField quantity;
    public string cardName;
    public string id;

    public GameObject newPanel;

    public TMP_Text title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        int number = int.Parse(quantity.text);
        appendList(id, number);
    }

    public void openPanel()
    {
        title.text = cardName;
        newPanel.SetActive(true);
    }

    private void appendList(string ID, int number)
    {
        string file = ListChooser.workingFile;

        if(new FileInfo(file).Exists)
        {
            if(new FileInfo(file).Length > 0)
            {
                string json; //WIll be set to the full json data for each card
                using (StreamReader sr = new StreamReader(file)) //Read the file of the full JSON file
                {
                    json = sr.ReadToEnd(); //Read through the entire file, set json to the string that is generated
                    sr.Close(); //Close the reader
                }
                DeckClass deck = JsonConvert.DeserializeObject<DeckClass>(json);
                for (int i = 0; i < int.Parse(quantity.text); i++)
                {
                    deck.ids.Add(ID);
                }
                string newData = JsonConvert.SerializeObject(deck);
                File.WriteAllText(file, newData);
            }

            else
            {
                DeckClass deck = new DeckClass();
                deck.ids = new List<string>();
                for (int i = 0; i < int.Parse(quantity.text); i++)
                {
                    deck.ids.Add(ID);
                }
                string newData  = JsonConvert.SerializeObject(deck);
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine(newData);
                    sw.Close();
                }
            }
            newPanel.SetActive(false);
        }

        else
        {
            DeckClass deck = new DeckClass();
            deck.ids = new List<string>();
            for (int i = 0; i < int.Parse(quantity.text); i++)
            {
                deck.ids.Add(ID);
            }
            string newData = JsonConvert.SerializeObject(deck);
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine(newData);
                sw.Close();
            }
            newPanel.SetActive(false);
        }

        
    }
}
