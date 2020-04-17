using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using TMPro;
using MtgApiManager.Lib.Service;
using UnityEngine.UI;

public class Builder_Card : MonoBehaviour, IPointerClickHandler //, IPointerEnterHandler, IPointerExitHandler, 
{
    public string id;

    public string cardName;
    public string cardText;
    public string[] types;
    public float? CMC;

    public GameObject infoPanel;
    public TMP_Text cardNameTitle;
    public TMP_Text cardTextTitle;
    public TMP_Text cardTypesTitle;
    public TMP_Text cardCMCTitle;

    private bool setValues;


    private void Start()
    {
        setValues = false;
        infoPanel.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        infoPanel.SetActive(true);
        if (!setValues)
        {
            StartCoroutine(SetPanel());
            setValues = true;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoPanel.SetActive(false);
    }

    private void Update()
    {
        GetComponent<BoxCollider2D>().size = GetComponent<Image>().sprite.rect.size;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("Manager").GetComponent<SaveToList>().cardName = gameObject.name;
        GameObject.Find("Manager").GetComponent<SaveToList>().id = id;
        GameObject.Find("Manager").GetComponent<SaveToList>().openPanel();
    }

    private IEnumerator SetPanel()
    {
        CardService service = new CardService();
        var result = service.Find(id);
        var values = result.Value;
        cardName = values.Name;
        cardText = values.Text;
        types = values.Types;
        CMC = values.Cmc;
        cardNameTitle.text = cardName;
        cardTextTitle.text = cardText;
        string type = "";
        foreach (string i in types)
        {
            type += i;
        }
        cardTypesTitle.text = type;
        cardCMCTitle.text = "CMC: " + CMC.ToString();
        yield return null;
    }
}
