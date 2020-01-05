using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Create_Cards : MonoBehaviour
{


    public GameObject cardPrefab; //The prefab to create instances from
    public TextAsset textAsset;


    // Start is called before the first frame update
    void Start()
    {
        createobjects();
    }

    private void createobjects()
    {
        string JSONString = File.ReadAllText(AssetDatabase.GetAssetPath(textAsset));
        Debug.Log(JSONString);
        cardList[] list = JsonHelper.FromJson<cardList>(JSONString);
        Debug.Log(list[0]);
/*        Card bruh = new Card();
        bruh.Artist = "bruh";
        AssetDatabase.CreateAsset(bruh, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();*/
    }
}

public class cardList //The class to attach json data to
{
    public string artist;
    public string[] colors;
    public string convertedManaCost;
    public string manaCost;
    public string name;
    public string number;
    public string originalText;
    public string originalType;
    public string power;
    public string rarity;
    public string[] rulings;
    public string[] subtypes;
    public string[] supertypes;
    public string type;
    public string flavorText;
    public string description;
}