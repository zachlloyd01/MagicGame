using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchtest : MonoBehaviour
{
    GameObject bruh;
    // Start is called before the first frame update
    void Start()
    {
        bruh = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void search()
    {
        foreach (CardData card in bruh.GetComponent<ListStorage>().cards)
        {
            if(card.cmc < 6)
            {
                Debug.Log(card.name);
            }
        }
    }
}
