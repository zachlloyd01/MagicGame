using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{

    public GameObject board;
    // Start is called before the first frame update
    void Start()
    {
        board = Instantiate(board);
        board.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
