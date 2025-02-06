using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject game;
    public Button start;
    public GameObject screen;

    void Start()
    {
        start.onClick.AddListener(BeginGame);
    }

    void BeginGame() // Cambié el nombre del método
    {
        screen.SetActive(false);
        game.SetActive(true);
    }
}
