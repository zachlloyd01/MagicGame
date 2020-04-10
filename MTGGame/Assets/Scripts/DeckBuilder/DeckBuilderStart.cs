using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class DeckBuilderStart : MonoBehaviour
{

    #region Object References

    public GameObject cardPrefab; //Card Template
    public GameObject deckBuilder; //Deck Builder UI
    public GameObject chooseList; //Button UI
    public GameObject content; //Scrollview

    #endregion

    #region Controls

    [Tooltip("Which set will we play?")]
    public string SetCode; //Which set to use

    #endregion

    #region Private Variables

    private GameObject tempObject; //Set card values using this
    private CardService service = new CardService(); //API Wrapper

    #endregion

    void Start() // Start is called before the first frame update
    {
        InitialValueSetting(); //Setup the scene
        InitialQuery(); //Get assortment of 100 cards from API
       
    }

    #region Scene Setup

    private void InitialValueSetting() //Called from Start()
    {
        //Initial UI Setup

        deckBuilder.SetActive(false); 
        chooseList.SetActive(true);

        //Deckbuilder UI setup
        content.GetComponent<GridLayoutGroup>().padding.left = Convert.ToInt32((Screen.width / 2) / 50);
        content.GetComponent<GridLayoutGroup>().padding.right = Convert.ToInt32(Screen.width * .002);
    }

    private void InitialQuery() //Called from Start()
    {
        Exceptional<List<Card>> result = service.Where(x => x.Set, SetCode).Where(x => x.PageSize, 100).Where(x => x.Page, 1).All(); //QUery the API
        if (result.IsSuccess) //If the API returns a result
        {
            var value = result.Value; //results
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
    }

    #endregion

    private IEnumerator GetSprite(string url, string CardName, string id) //Called from InitialQuery()
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
