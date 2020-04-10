using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Model;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardSearch : MonoBehaviour
{
    #region Editor References

    public TMP_InputField searchBar; //User Query
    public GameObject cardPrefab; //Card Template
    public GameObject content; //Scrollview

    #endregion

    #region Private Variables

    private GameObject tempObject; //Set Card Values
    private CardService service = new CardService(); //API Wrapper
    private bool allowEnter; //Searchbar control

    #endregion

    void Update()
    {

        if (allowEnter && (searchBar.text.Length > 0) && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            Search();
            allowEnter = false;
        }
        else 
        { 
            allowEnter = searchBar.isFocused; 
        }
    }

    #region Search Query

    public void Search() //Called from Update()
    {
        string query = searchBar.text; //Get the user Query

        var result = service.Where(x => x.Name, query).Where(x => x.Set, GetComponent<DeckBuilderStart>().SetCode).All(); //Get all cards that match the query
        var value = result.Value; //Resultant values
        newQuery(value); //Generate the cards
    }

    private void newQuery(List<Card> value) //Called from Search()
    {
        destroyPrevQuery(); //Get rid of old cards
        for (int i = 0; i < value.Count; i++) //Iterate over the cards
        {
            try //Try & Catch because if the value is empty it will return null values instead of nothing
            {
                string url = value[i].ImageUrl.ToString(); //Get the card image
                string CardName = value[i].Name; //Card Name
                string id = value[i].Id; //Card ID
                StartCoroutine(GetSprite(url, CardName, id)); //Set the card values
            }
            catch
            {
                //Do Nothing
            }

        }
    }

    private void destroyPrevQuery() //Called from newQuery()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("DeckbuilderCard")) //Find all cards in the scene
        {
            if (go != null) //If the card is still in the scene
            {
                Destroy(go); //Destroy the card
            }
        }
    }

    #endregion

    private IEnumerator GetSprite(string url, string CardName, string id) //Called from newQuery()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url); //Get the card image from the web
        yield return www.SendWebRequest(); //Send the HTTP Request
        Texture2D cardTexture = ((DownloadHandlerTexture)www.downloadHandler).texture; //COnvert the image to a texture
        cardTexture.filterMode = FilterMode.Point; // Removes pixel averaging
        tempObject = Instantiate(cardPrefab); //, spawnLocation, Quaternion.identity);

        tempObject.transform.SetParent(content.transform, false); //Put cards onto the scrollview
        tempObject.name = CardName; //Set Editor name values
        tempObject.GetComponent<Builder_Card>().id = id; //Set the card id
        tempObject.GetComponent<Image>().sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(0, 0)); //Create the card in the scene
    }
}
