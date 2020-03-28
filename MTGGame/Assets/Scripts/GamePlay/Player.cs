using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public List<GameObject> Deck; // ordered
  public List<GameObject> Hand; // order does not matter
  public List<GameObject> Graveyard; // ordered

  void Start() { // on creation
    Deck = new List<GameObject>();
    Hand = new List<GameObject>();
    Graveyard = new List<GameObject>();

    fillDeck();
    shuffleDeck();
    drawCards(7);
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
      Deck.RemoveAt(0);
    }
  }

  void fillDeck () { // fills deck with cards
    int size = 60; // normal deck size
    GameObject prefab = this.transform.parent.GetComponent<GameMaster>().cardPrefab;
    for (int i = 0; i < size; i++) {
      Deck.Add(Instantiate(prefab, new Vector2(0, 0), Quaternion.identity));
      Deck[i].transform.SetParent(this.transform);
      Deck[i].AddComponent<Card>();
      Deck[i].GetComponent<Card>().SetValues(this.transform.parent.GetComponent<GameMaster>().sampleCard); // TODO: Set up prebuilt decks
    }
  }
}
