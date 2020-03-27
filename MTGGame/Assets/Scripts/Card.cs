using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler
{
    private string url;
    public TextAsset _CardData;
    public CardData data;
    private Image image;

    private void Awake()
    {
        data = JsonConvert.DeserializeObject<CardData>(_CardData.text);
        url = data.image_uris.png;
    }
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(RenderSprite());
        gameObject.name = data.name;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
