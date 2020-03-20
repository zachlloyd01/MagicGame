using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string url;
    public TextAsset _CardData;
    public CardData data;

    private void Awake()
    {
        data = JsonConvert.DeserializeObject<CardData>(_CardData.text);
        url = data.image_uris.png;
    }
    // Start is called before the first frame update
    void Start()
    {
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
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }
}
