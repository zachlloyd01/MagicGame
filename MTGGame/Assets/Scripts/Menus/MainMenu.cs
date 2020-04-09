using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deckBuilder()
    {
        SceneManager.LoadScene("DeckBuilding", LoadSceneMode.Single);
    }

    public void Play()
    {
        SceneManager.LoadScene("Launcher", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}