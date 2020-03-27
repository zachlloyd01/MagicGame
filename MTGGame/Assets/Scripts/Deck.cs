using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour, IPointerDownHandler
{
    public List<TextAsset> cardList = new List<TextAsset>();

    public GameObject cardPrefab;

    private void Awake()
    {
        cardList.Shuffle<TextAsset>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TextAsset data = cardList[0];
        cardPrefab.GetComponent<Card>()._CardData = data;
        cardPrefab.transform.parent = gameObject.transform.parent;
        cardPrefab = Instantiate(cardPrefab);
        cardPrefab.transform.parent = gameObject.transform.parent;
    }
}
