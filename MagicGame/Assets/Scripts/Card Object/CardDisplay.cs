using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    public cardGenerate card;

    public Text nameText;

    public Image artImage;
    public Text description;

    private int toughness;
    private int attack;

    public Text type;
    public Text damageandhealth;

    public bool isTapped = false;

    // Start is called before the first frame update
    private void Start()
    {
        setVals();
    }
    private void Update()
    {

    }

    public void setVals()
    {
        nameText.text = card.Name;
        artImage.sprite = card.Artwork;
        description.text = card.Text;
        toughness = card.Toughness;
        attack = card.Power;
        type.text = card.Type;

        damageandhealth.text = attack.ToString() + "/" + toughness.ToString();
    }

    private void OnMouseDown()
    {
        if (transform.parent == GameObject.Find($"{gameObject.GetComponent<PhotonView>().Owner} - Hand").transform) //If the parent of the card is the hand of the same owner
        {
            transform.parent = GameObject.Find($"{gameObject.GetComponent<PhotonView>().Owner} - Board").transform; //Move it to that player's board
        }
        else if(transform.parent == GameObject.Find($"{gameObject.GetComponent<PhotonView>().Owner} - Board").transform) //If the card is already on the board
        {
            if(!isTapped) //Tapped?
            {
                gameObject.transform.Rotate(0, 90, 0); //Rotate the card 90 degrees
                isTapped = true;
            }
            else
            {
                gameObject.transform.Rotate(0, -90, 0); //Rotate it back
                isTapped = false;
            }
        }
        else
        {
            Destroy(gameObject); //If it is has no parent/owner, destroy it so it doesn't cause errors
        }
    }

}