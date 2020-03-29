using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Builder_Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public void OnPointerEnter(PointerEventData eventData) //display info panel
    {
        
    }

    public void OnPointerExit(PointerEventData eventData) //remove info panel
    {
        
    }

    private void Update()
    {
        GetComponent<BoxCollider2D>().size = GetComponent<Image>().sprite.rect.size;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("Manager").GetComponent<SaveToList>().cardName = gameObject.name;
        GameObject.Find("Manager").GetComponent<SaveToList>().openPanel();
        Debug.Log("open");
    }
}
