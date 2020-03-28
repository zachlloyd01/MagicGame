using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class ListStorage : MonoBehaviour
{
    public List<CardData> cards;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        TextAsset[] objs = Resources.LoadAll<TextAsset>("JsonObjects");
        Debug.Log(objs.Length);
        foreach (TextAsset card in objs)
        {
            CardData newCard = JsonConvert.DeserializeObject<CardData>(card.ToString());
            cards.Add(newCard);

        }
        SceneManager.LoadScene("DeckBuilding", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
