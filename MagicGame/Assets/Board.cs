using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject deck;
    // Start is called before the first frame update
    void Start()
    {
        deck = Instantiate(deck);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
