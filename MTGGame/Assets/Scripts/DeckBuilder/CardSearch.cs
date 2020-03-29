using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardSearch : MonoBehaviour
{
    public TMP_InputField searchBar;
    public GameObject cardPrefab;
    public GameObject content;

    private CardService service = new CardService();


    public void Search()
    {
        string query = searchBar.text;

        var result = service.Where(x => x.Name, query).All();
        var value = result.Value;
        destroyPrevQuery();
        newQuery(value);
    }

    private void newQuery(List<Card> value)
    {
        for (int i = 0; i < value.Count; i++)
        {
            // Debug.Log(value[i].Name);
            try
            {
                string url = value[i].ImageUrl.ToString();
                string CardName = value[i].Name;
                StartCoroutine(GetSprite(url, CardName));

            }
            catch
            {

            }

        }
    }

    private void destroyPrevQuery()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("DeckbuilderCard"))
        {
            Destroy(go);
        }
    }

    private IEnumerator GetSprite(string url, string CardName)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        Texture2D cardTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        cardTexture.filterMode = FilterMode.Point; // Removes pixel averaging
        cardPrefab = Instantiate(cardPrefab); //, spawnLocation, Quaternion.identity);
        cardPrefab.transform.SetParent(content.transform, false);
        cardPrefab.name = CardName;
        cardPrefab.GetComponent<Image>().sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(0, 0));
        // Debug.Log(image.texture.filterMode);
    }
}
