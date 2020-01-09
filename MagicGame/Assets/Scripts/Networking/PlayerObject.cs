using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{

    public GameObject playerDeck;
    // Start is called before the first frame update
    void Start()
    {
        playerDeck = Instantiate(playerDeck);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
