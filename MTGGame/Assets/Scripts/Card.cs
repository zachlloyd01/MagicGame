//using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.Networking;
//using UnityEngine.UI;

public class Card
{
  public string cardName; // Not using "name" because of object.name
  public int cmc; // TODO: Make mana cost object instead of cmc

  private string url;
  public TextAsset _CardData;
  // public CardData data; // no class version in project?
  // private Image image; // namespace image not found

  public Card () // same as start() for init object
  {
      image = GetComponent<Image>();
      StartCoroutine(RenderSprite());
      gameObject.name = data.name;
  }

  private void Awake()
  {
      data = JsonConvert.DeserializeObject<CardData>(_CardData.text);
      url = data.image_uris.png;
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

  /* public void OnPointerEnter(PointerEventData eventData) // errors out
  {
      throw new System.NotImplementedException();
  }*/
}

public class Land : Card {
  public string type;

  public Land(string type) {
    this.cmc = 0;
    this.type = type;
  }
}

public class Creature : Card {
  public int toughness;
  public int currToughness;
  public int power;
}

public class Artifact : Card {

}

public class Spell : Card {
  public class Enchantment : Spell {

  }

  public class Instant : Spell {

  }

  public class Scorcery : Spell {

  }
}

public class Planeswalker : Card {

}
