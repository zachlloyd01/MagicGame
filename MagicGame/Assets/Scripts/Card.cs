using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject //Scriptable Object allows Unity to create instances of this object from the editor
{

    //Everything here should be fairly self explanatory I hope
    public string Name;
    public string type;

    public string description;

    public Sprite artwork; //Will be converted to image on display

    public int attack;
    public int damage; //Is this the right name?

    /**
     * This part of code is for initializing object from code
     **/

    public void Init(string name, string type, string description, int attack, int damage) //Data pass-thru
    {
        this.name = name;
        this.type = type;
        this.description = description;
        this.attack = attack;
        this.damage = damage;
    }

    public static Card CreateInstance(string name, string type, string description, int attack, int damage) //Custom Constructor
    {
        var data = ScriptableObject.CreateInstance<Card>(); //an abstract var to hold the instance
        data.Init(name, type, description, attack, damage); //initialize the new data (WOW!? SELF EXPLANATORY AMIRITE??????)
        return data;
    }
}
