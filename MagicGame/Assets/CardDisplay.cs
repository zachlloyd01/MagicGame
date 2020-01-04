using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Image artImage;
    public Text description;

    private int damage;
    private int attack;

    public Text type;
    public Text damageandhealth;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.Name;
        artImage.sprite = card.artwork;
        description.text = card.description;
        damage = card.damage;
        attack = card.attack;
        type.text = card.type;

        damageandhealth.text = attack.ToString() + "/" + damage.ToString();
    }
}
