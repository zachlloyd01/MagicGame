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
using TMPro;

public class Play_Card : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public string cardName;
    public string cardText;
    public string[] types;
    public float? CMC;

    public GameObject infoPanel;
    public TMP_Text cardNameTitle;
    public TMP_Text cardTextTitle;
    public TMP_Text cardTypesTitle;
    public TMP_Text cardCMCTitle;

    private string url;
    private Image image;

    public bool isTapped;

    public string id;

    private PhotonView photonView;

    void OnEnable()
    {
        
    }

    void Start()
    {
        image = GetComponent<Image>();
        photonView = GetComponent<PhotonView>();
        isTapped = false;
        CardService service = new CardService();
        var result = service.Find(id);
        var values = result.Value;
        cardName = values.Name;
        cardText = values.Text;
        types = values.Types;
        CMC = values.Cmc;
        url = values.ImageUrl.ToString();
        infoPanel.SetActive(false);
        cardNameTitle.text = cardName;
        cardTextTitle.text = cardText;
        string type = "";
        foreach(string i in types)
        {
            type += i;
        }
        cardTypesTitle.text = type;
        cardCMCTitle.text = "CMC: " + CMC.ToString();
        // photonView.RPC("RenderSprite", RpcTarget.All);
        RenderSprite();
    }
    [PunRPC]
    public void RenderSprite()
    { // TODO: Fix sprite render on "Game" view
        StartCoroutine(Rendersprite());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isTapped)
        {
            GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));
            isTapped = true;
        }
        else
        {
            GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 90));
            isTapped = false;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoPanel.SetActive(false);
    }

    private IEnumerator Rendersprite()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        while (!www.isDone)
        {
            if (www.isNetworkError)
            {
                Debug.Log($"Could not download texture. Error is: \n{www.error}");
                Debug.Log("Retrying.");
                RenderSprite();
            }
        }
        Texture2D cardTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        cardTexture.filterMode = FilterMode.Point; // Removes pixel averaging
        image.sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(0, 0));
    }
}
