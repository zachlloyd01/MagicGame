using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageRendererTest : MonoBehaviour
{

    public TextAsset cardData;

    private GameObject testObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void renderTest()
    {
        CardData data = JsonConvert.DeserializeObject<CardData>(cardData.ToString());
        Debug.Log(data.image_uris.png);
        StartCoroutine(GetImg(data.image_uris.png));
    }

    IEnumerator GetImg(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        testObject = new GameObject();
        testObject.name = "testObject";
        testObject.AddComponent<SpriteRenderer>();
        testObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }
}
