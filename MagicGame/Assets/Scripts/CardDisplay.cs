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

    // Start is called before the first frame update
    private void Start()
    {
        nameText.text = card.Name;
        artImage.sprite = card.Artwork;
        description.text = card.Text;
        toughness = card.Toughness;
        attack = card.Power;
        type.text = card.Type;

        damageandhealth.text = attack.ToString() + "/" + toughness.ToString();
    }
    private void Update()
    {
        
    }
}
