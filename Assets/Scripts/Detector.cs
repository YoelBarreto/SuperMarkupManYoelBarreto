using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public Material greenMaterial; // Material verde que se aplicará en la colisión
    
    // Variable bool que se actualizará al ser su Tag
    public bool rightTag = false;  

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // Compara el nombre del objeto que colisiona con el nombre de este objeto
        if (other.gameObject.name == gameObject.name)
        {
            if (greenMaterial != null)
            {
                rightTag = true;  // Actualiza el estado a 'true'
            }
            else
            {
                Debug.LogWarning("El material verde no ha sido asignado en el Inspector.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el objeto que salió de la colisión tiene el mismo nombre, restaura el material original
        if (other.gameObject.name == gameObject.name)
        {
            rightTag = false; // Cambia el estado a 'false'
        }
    }
}
