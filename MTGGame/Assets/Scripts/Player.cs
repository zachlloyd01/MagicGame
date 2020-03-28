using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public List<Card> Deck; // ordered
  public List<Card> Hand; // order does not matter
  public List<Card> Graveyard; // ordered

  public Player() { // on creation
    Deck = new List<Card>();
    Hand = new List<Card>();
    Graveyard = new List<Card>();

    fillDeck();
    shuffleDeck();
    drawCards(7);
  }

  void shuffleDeck () { // shuffles deck using placement
    int n = Deck.Count;
    System.Random rng = new System.Random();
    while (n > 1) {
      int k = rng.Next(n--);
      Card temp = Deck[n];
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

  void fillDeck () {
    for (int i = 0; i < 60; i++) {
      Deck.Add(new Card());
    }
  }
}
