using System.Collections;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject lvl1; // Referencia al GameObject de nivel 1
    public GameObject lvl2; // Referencia al GameObject de nivel 2
    public GameObject lvl3; // Referencia al GameObject de nivel 3

    private int currentLevel = 1; // Comienza en el nivel 1
    public TMP_Text levelText;
    public GameObject transitionScreen;
    public GameObject endScreen; 

    void Start()
    {
        // Aseguramos que solo el nivel 1 esté activado al principio
        SetLevelActive("LVL1");
        UpdateLevelText();
    }

    // Función que activa el siguiente nivel
    public void ActivateNextLevel()
    {
        if (currentLevel == 1)
        {
            SetLevelActive("LVL2");
            currentLevel = 2; // Avanza al nivel 2
        }
        else if (currentLevel == 2)
        {
            SetLevelActive("LVL3");
            currentLevel = 3; // Avanza al nivel 3
        }
        else if (currentLevel == 3)
        {
            Debug.Log("¡Has completado todos los niveles!");
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }
        ShowTransitionScreen();
        UpdateLevelText();
    }

    // Función que activa un nivel específico y desactiva los demás
    private void SetLevelActive(string levelTag)
    {
        // Desactiva todos los niveles
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);

        // Activa el nivel correspondiente
        if (levelTag == "LVL1")
        {
            lvl1.SetActive(true);
        }
        else if (levelTag == "LVL2")
        {
            lvl2.SetActive(true);
        }
        else if (levelTag == "LVL3")
        {
            lvl3.SetActive(true);
        }
    }
    private void UpdateLevelText()
    {
        levelText.text = "LEVEL " + currentLevel.ToString();
    }

    // Función para mostrar la pantalla de transición y luego ocultarla después de 2 segundos
    private void ShowTransitionScreen()
    {
        transitionScreen.SetActive(true); // Muestra la pantalla de transición
        StartCoroutine(HideTransitionScreen()); // Inicia la corutina para ocultarla después de 2 segundos
    }

    // Corutina que ocultará la pantalla de transición después de 2 segundos
    private IEnumerator HideTransitionScreen()
    {
        yield return new WaitForSeconds(0.8f);
        transitionScreen.SetActive(false);
    }
}
