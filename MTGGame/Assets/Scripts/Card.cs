using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RenderSprite()
    {
        WWW www = new WWW(url);
        yield return www;
        image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        image.rectTransform.sizeDelta = new Vector2(www.texture.width, www.texture.height);
    }
}
