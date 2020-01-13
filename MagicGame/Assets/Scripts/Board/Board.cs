using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increment (int amount)
    {
        health += amount;
    }
}
