using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;

public class DeckBuilderStart : MonoBehaviour
{
    public CardService service = new CardService();
    public GameObject cardPrefab;
    public Vector3 Position = new Vector3(-922f, 1669f, 0);

    private GameObject tempObject;

    public GameObject deckBuilder;

    public GameObject chooseList;

    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        deckBuilder.SetActive(false);
        chooseList.SetActive(true);
        content.GetComponent<GridLayoutGroup>().padding.left = Convert.ToInt32(Screen.width * .2);
        content.GetComponent<GridLayoutGroup>().padding.right = Convert.ToInt32(Screen.width * .2);
        Exceptional<List<Card>> result = service.All();
        if(result.IsSuccess)
        {
            var value = result.Value;
            for (int i = 0; i < value.Count; i++) {
                // Debug.Log(value[i].Name);
                try
                {
                    string url = value[i].ImageUrl.ToString();
                    string CardName = value[i].Name;
                    string id = value[i].Id;
                    StartCoroutine(GetSprite(url, CardName, id));
                    
                }
                catch
                {

                }
                
            }
        }

    }


    public IEnumerator GetSprite(string url, string CardName, string id)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        Texture2D cardTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        cardTexture.filterMode = FilterMode.Point; // Removes pixel averaging
        tempObject = Instantiate(cardPrefab); //, spawnLocation, Quaternion.identity);
        
        tempObject.transform.SetParent(content.transform, false);
        tempObject.name = CardName;
        tempObject.GetComponent<Builder_Card>().id = id;
        tempObject.GetComponent<Image>().sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(0, 0));
        // Debug.Log(image.texture.filterMode);
    }
}
