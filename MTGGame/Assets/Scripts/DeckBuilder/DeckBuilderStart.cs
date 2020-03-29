﻿using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DeckBuilderStart : MonoBehaviour
{
    public CardService service = new CardService();
    public GameObject cardPrefab;
    public Vector3 Position = new Vector3(-922f, 1669f, 0);
    public Vector3 temp = new Vector3(5f, 0, 0);

    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        Exceptional<List<Card>> result = service.All();
        if(result.IsSuccess)
        {
            var value = result.Value;
            for (int i = 0; i < value.Count; i++) {
                Debug.Log(value[i].Name);
                try
                {
                    string url = value[i].ImageUrl.ToString();
                    string CardName = value[i].Name;
                    StartCoroutine(GetSprite(url, CardName, Position));
                    if(Position.x >= 889)
                    {
                        Position = new Vector3(-922f, Position.y - 415, 0);
                    }
                    else
                    {
                        Position += new Vector3(287, 0, 0);
                    }
                    
                }
                catch
                {

                }
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator GetSprite(string url, string CardName, Vector3 spawnLocation)
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