using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using TMPro;
using MtgApiManager.Lib.Service;
using UnityEngine.UI;

public class Builder_Card : MonoBehaviour, IPointerClickHandler
{
    public string id;

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
}
