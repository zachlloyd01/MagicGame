using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public List<GameObject> Deck; // ordered
  public List<GameObject> Hand; // order does not matter
  public List<GameObject> Graveyard; // ordered

  Canvas Master;
  float cardLength;

  void Start() { // on creation
    Deck = new List<GameObject>();
    Hand = new List<GameObject>();
    Graveyard = new List<GameObject>();

    Master = FindObjectOfType<Canvas>();

    fillDeck();
    shuffleDeck();
    drawCards(7);
    handPositionSet();
    if (this.name == "Player #2") {
      flipPosition();
    }
  }

  void shuffleDeck () { // shuffles deck using placement
    int n = Deck.Count;
    System.Random rng = new System.Random();
    while (n > 1) {
      int k = rng.Next(n--);
      GameObject temp = Deck[n];
      Deck[n] = Deck[k];
      Deck[k] = temp;
    }
  }

  void drawCards (int amount) { // puts cards from library to hand
    for (int i = 0; i < amount; i++) {
      Hand.Add(Deck[0]);
      // StartCoroutine(Hand[i].GetComponent<Play_Card>().RenderSprite()); // reveals card
      Deck.RemoveAt(0);
    }
  }

  void fillDeck () { // fills deck with cards
    int size = 60; // normal deck size
    GameObject prefab = this.transform.parent.GetComponent<GameMaster>().cardPrefab;
    cardLength = prefab.GetComponent<RectTransform>().sizeDelta.x * prefab.GetComponent<RectTransform>().transform.localScale.x + 5;
    for (int i = 0; i < size; i++) {
      RectTransform canvas = Master.GetComponent<RectTransform>();
      float canvasSize = canvas.sizeDelta.x * canvas.transform.localScale.x;
      Deck.Add(Instantiate(prefab, new Vector2(canvasSize - cardLength / 2, 90), Quaternion.identity));
      Deck[i].transform.SetParent(this.transform);
      Deck[i].AddComponent<Play_Card>();
      // Deck[i].GetComponent<Play_Card>().SetValues(this.transform.parent.GetComponent<GameMaster>().sampleCard); // TODO: Set up prebuilt decks
    }
  }

  void handPositionSet () { // TODO: Make UI cleaner
    for (int i = 0; i < Hand.Count; i++) {
      RectTransform canvas = Master.GetComponent<RectTransform>();
      float middle = canvas.sizeDelta.x * canvas.transform.localScale.x / 2f;
      Hand[i].transform.position = new Vector2(middle - (Hand.Count - 1) * cardLength / 2 + i * cardLength, 90); // TODO: Better math
    }
  }

  void flipPosition  () {
    RectTransform canvas = Master.GetComponent<RectTransform>();
    float canvasSizeX = canvas.sizeDelta.x * canvas.transform.localScale.x;
    float canvasSizeY = canvas.sizeDelta.y * canvas.transform.localScale.y;

    foreach (Transform child in transform) { // All cards player owns
      child.transform.position = new Vector2(canvasSizeX - child.transform.position.x, canvasSizeY - child.transform.position.y);
      child.transform.Rotate(180, 0, 0, Space.Self);
    }
  }
}
