using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ViewDeck : MonoBehaviour
{
    public GameObject deckBuilderUI;
    public GameObject deckViewerUI;

    public GameObject manager;

    public GameObject viewerCardPrefab;

    public GameObject content;

    private CardService service = new CardService();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDeck()
    {
        HideBuilder();
        GetCards();
    }

    private void HideBuilder()
    {
        deckBuilderUI.SetActive(false);
        deckViewerUI.SetActive(true);
    }

    private void ShowBuilder()
    {
        
    }

    private void GetCards()
    {
        string workingFile = manager.GetComponent<ListChooser>().workingFile;
        string json;

        using (StreamReader sr = new StreamReader(workingFile))
        {
            json = sr.ReadToEnd();
            sr.Close();
        }

        DeckClass deck = JsonConvert.DeserializeObject<DeckClass>(json);
        foreach(string id in deck.ids)
        {
            Card card = service.Find("id").Value;
            StartCoroutine(PlaceCard(card));
        }

    }

    private IEnumerator PlaceCard(Card card) 
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(card.ImageUrl.ToString());
        yield return www.SendWebRequest();
        while(!www.isDone)
        {
            if (www.isNetworkError)
            {
                Debug.Log($"Could not download texture. Error is: \n{www.error}");
                Debug.Log("Will not retry.");
            }
        }
        Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        texture.filterMode = FilterMode.Point;
        GameObject tempObject = Instantiate(viewerCardPrefab);
        tempObject.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
        tempObject.transform.parent = content.transform;
    }

    
}
