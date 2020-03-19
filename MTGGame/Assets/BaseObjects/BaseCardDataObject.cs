using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCardDataObject : ScriptableObject
{
    public new string name { get; set; }
    public string manaCost { get; set; }
    public string cmc { get; set; }
    public string[] colors { get; set; }
    public string type { get; set; }
    public string[] subTypes { get; set; }
    public string text { get; set; }
    public string power { get; set; }
    public string toughness { get; set; }
    public string imageName { get; set; }

    public void init(string Name, string ManaCost, string Cmc, string[] Colors, string Type, string[] Subtypes, string Text, string Power, string Toughness, string ImageName)
    {
        name = Name;
        manaCost = ManaCost;
        cmc = Cmc;
        colors = Colors;
        type = Type;
        subTypes = Subtypes;
        text = Text;
        power = Power;
        toughness = Toughness;
        imageName = ImageName;
    }
}
