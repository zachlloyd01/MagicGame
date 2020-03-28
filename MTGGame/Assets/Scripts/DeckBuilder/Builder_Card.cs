using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Builder_Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int cmc; // TODO: Make mana cost object instead of cmc

    private string url;
    public CardData data;
    private Image image;

    public void SetValues(string _CardData)
    { // sets up card based off of card #
        image = GetComponent<Image>();
        data = JsonConvert.DeserializeObject<CardData>(_CardData);
        url = data.image_uris.png;
        StartCoroutine(RenderSprite());
        gameObject.name = data.name;
    }

    private IEnumerator RenderSprite()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        Texture2D cardTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        image.sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(0, 0));
        image.transform.localScale = new Vector2(2.5f, 3.5f);
        image.transform.position = Vector3.zero;
    }

    public void OnPointerEnter(PointerEventData eventData) //display info panel
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData) //remove info panel
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData) //add to deck
    {
        throw new System.NotImplementedException();
    }
}
