using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    public bool isTapped;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isTapped = false;
        rotationSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        tapCard();
    }

    public void tapCard()
    {
        if (isTapped == false)
        {
            isTapped = true;
            transform.Rotate(new Vector3(0, 90, 0));
        }

        else
        {
            isTapped = false;
            transform.Rotate(new Vector3(0, -90, 0) * (rotationSpeed * Time.deltaTime));
        }
    }
}
