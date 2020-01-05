using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Web.Script.Serialization;

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
        var JsonObj = new JavaScriptSerializer().Deserialize<RootObj>(textAsset.text);
        foreach(var obj in JsonObj.objectList)
        {
            Debug.Log(obj.artist);
        }
/*        Card bruh = new Card();
        bruh.Artist = "bruh";
        AssetDatabase.CreateAsset(bruh, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();*/
    }
}

public class cardList //The class to attach json data to
{
    public string artist { get; set;  }
    public string[] colors { get; set; }
    public string convertedManaCost { get; set; }
    public string manaCost { get; set; }
    public string name { get; set; }
    public string number { get; set; }
    public string originalText { get; set; }
    public string originalType { get; set; }
    public string power { get; set; }
    public string rarity { get; set;  }
public string[] rulings { get; set; }
    public string[] subtypes { get; set; }
    public string[] supertypes { get; set; }
    public string type { get; set; }
    public string flavorText { get; set; }
    public string description { get; set; }
}

public class RootObj
{
    public string objectType { get; set; }
    public List<cardList> objectList { get; set; }
}