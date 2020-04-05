using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using Newtonsoft.Json;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Play_Card : MonoBehaviour, IPointerEnterHandler
{
    private string url;
    private Image image;

    private CardService service = new CardService();

    public string id;

    private PhotonView photonView;

    void OnEnable()
    {
        photonView = GetComponent<PhotonView>();
        var result = service.Where(x => x.Name, this.name).All();
        if(result.IsSuccess)
        {
            url = result.Value[0].ImageUrl.ToString();
        }
        photonView.RPC("RenderSprite", RpcTarget.All);
    }

    [PunRPC]
    public void RenderSprite()
    { // TODO: Fix sprite render on "Game" view
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        www.SendWebRequest();
        while (!www.isDone)
        {
            if(www.isNetworkError)
            {
                Debug.Log($"Could not download texture. Error is: \n{www.error}");
                Debug.Log("Retrying.");
                RenderSprite();
            }
        }
        Texture2D cardTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        cardTexture.filterMode = FilterMode.Point; // Removes pixel averaging
        image.sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(0, 0));
        // Debug.Log(image.texture.filterMode);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
