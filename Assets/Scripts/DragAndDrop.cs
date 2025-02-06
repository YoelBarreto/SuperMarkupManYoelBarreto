using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;

    void Start()
    {
        cam = Camera.main; // Obtener la cámara principal
    }

    private void OnMouseDown()
    {
        // Convertir la posición del mouse en el mundo y calcular la diferencia
        offset = transform.position - GetMouseWorldPos();
        isDragging = true; // Indicar que el objeto está siendo arrastrado
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Mover el objeto con el mouse respetando la posición original en Z
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false; // Indicar que el objeto ya no está siendo arrastrado
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z; // Mantener la profundidad correcta
        return cam.ScreenToWorldPoint(mousePoint); // Convertir la posición de pantalla a coordenadas del mundo
    }
}