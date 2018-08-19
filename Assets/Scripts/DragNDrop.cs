using System.Collections;
using UnityEngine;

class DragNDrop : MonoBehaviour
{
    float distance = 10;
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}