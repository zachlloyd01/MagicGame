using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler {
  private string url;
  public CardData data;
  private Image image;

  public void SetValues (TextAsset _CardData) { // sets up card
    image = GetComponent<Image>();
    data = JsonConvert.DeserializeObject<CardData>(_CardData.text);
    url = data.image_uris.png;
    gameObject.name = data.name;
  }

  public IEnumerator RenderSprite() { // TODO: Fix sprite render on "Game" view
    UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
    yield return www.SendWebRequest();
    Texture2D cardTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
    cardTexture.filterMode = FilterMode.Point; // Removes pixel averaging
    image.sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(0, 0));
    // Debug.Log(image.texture.filterMode);
  }

  public void OnPointerEnter(PointerEventData eventData) {
    throw new System.NotImplementedException();
  }
}
