using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI, como botones

public class GameManager : MonoBehaviour
{
    public Detector object1; // Arrastra el objeto con el script de colisión
    public Detector object2;
    public Detector object3;
    public Detector object4;
    public Button winButton; // El botón que activará la acción
    public LevelManager levelManager; // Referencia al LevelManager

    private bool hasWon = false; // Para asegurarnos de que el mensaje solo se imprima una vez
    private bool levelCompleted = false; // Nueva variable para saber si el nivel ha sido completado

    void Start()
    {
        // Asocia la función al evento del botón
        winButton.onClick.AddListener(OnWinButtonClick);
    }

    void Update()
    {
        // Verificamos si todos los objetos tienen el bool "rightTag" a true
        if (object1.rightTag && object2.rightTag && object3.rightTag && object4.rightTag)
        {
            // Si no se ha mostrado el mensaje "Gana" aún, lo mostramos
            if (!hasWon)
            {
                Debug.Log("Gana");
                hasWon = true; // Establecemos que ya se mostró el mensaje
            }
        }
        else
        {
            // Si en algún momento un bool se pone a false, reiniciamos el estado de "hasWon"
            hasWon = false;
        }
    }

    // Función que se ejecuta cuando el botón es presionado
    void OnWinButtonClick()
    {
        if (hasWon && !levelCompleted)
        {
            // Habilita el GameObject
            levelCompleted = true; // Marca el nivel como completado
            levelManager.ActivateNextLevel(); // Llama a LevelManager para activar el siguiente nivel
        }
    }
}
