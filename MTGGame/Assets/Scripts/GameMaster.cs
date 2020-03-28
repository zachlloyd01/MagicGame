using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
  public GameObject[] Players;
  public List<Card> Battlefield;
  public List<Card> Stack;
  public List<Card> Exile;

  void Start() {
    Players = new GameObject[2];
    fillGame();
  }

  void Update() {

  }

  void fillGame () {
    for (int i = 0; i < Players.Length; i++) {
      Players[i] = new GameObject("Player #" + (i + 1));
      Players[i].AddComponent<Player>();
    }
  }
}
