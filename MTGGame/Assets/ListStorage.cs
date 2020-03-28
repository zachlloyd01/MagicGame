using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListStorage : MonoBehaviour
{
    public CardData[] cards;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
       /* var objs = AssetDatabase.LoadAllAssetsAtPath("Assets/CardData/JsonObjects");
        foreach (TextAsset json in objs)
        {
            CardData card = JsonConvert.DeserializeObject<CardData>(json.ToString());
            cards.Add(card);
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
