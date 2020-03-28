using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
  public GameObject[] Players;
  public List<GameObject> Battlefield; // order does not matter
  public List<GameObject> Stack; // ordered
  public List<GameObject> Exile; // order does not matter

  public GameObject cardPrefab;
  public TextAsset sampleCard; //temporary

  void Start() {
    Players = new GameObject[2];
    fillGame();
  }

  void fillGame () {
    for (int i = 0; i < Players.Length; i++) {
      Players[i] = new GameObject("Player #" + (i + 1));
      Players[i].transform.parent = this.transform;
      Players[i].AddComponent<Player>();
    }
  }
}
