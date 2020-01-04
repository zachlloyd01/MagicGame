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

}
