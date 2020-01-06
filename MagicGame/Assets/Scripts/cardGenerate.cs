﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class cardGenerate : ScriptableObject //Scriptable Object allows Unity to create instances of this object from the editor
{

    // Card Attributes
    private string artist;
    private Sprite artwork; //Will be converted to image on display
    private string colorIdentity;
    private string colors;
    private int convertedManaCost;
    private string flavorText;
    // private bool isFoil; add later?
    private string manaCost;
    private string cardName;
    private int number; // i.e. set number
    private string rarity;
    private string rulings;
    private string set;
    private string[] subtypes; // ex. Elemental
    private string[] supertypes; // ex. Legendary
    private string text; // oracle text
    private int power;
    private int toughness;
    private string type; // ex. Legendary Artifact Creatu

    private string[] types; // ex. Artifact Creature


    public cardGenerate() { }
    // recieve & send attributes through get & set
    public string Artist { get => artist; set => artist = value; }
    public Sprite Artwork { get => artwork; set => artwork = value; }
    public string ColorIdentity { get => colorIdentity; set => colorIdentity = value; }
    public string Colors { get => colors; set => colors = value; }
    public int ConvertedManaCost { get => convertedManaCost; set => convertedManaCost = value; }
    public string ManaCost { get => manaCost; set => manaCost = value; }
    public string Name { get => cardName; set => cardName = value; }
    public int Number { get => number; set => number = value; }
    public int Power { get => power; set => power = value; }
    public string Rarity { get => rarity; set => rarity = value; }
    public string Rulings { get => rulings; set => rulings = value; }
    public string Set { get => set; set => set = value; }
    public string[] Subtypes { get => subtypes; set => subtypes = value; }
    public string[] Supertypes { get => supertypes; set => supertypes = value; }
    public string Text { get => text; set => text = value; }
    public int Toughness { get => toughness; set => toughness = value; }
    public string Type { get => type; set => type = value; }
    public string[] Types { get => types; set => types = value; }

}