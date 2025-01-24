using System;
using UnityEngine;



public class BubbleDrag : MonoBehaviour
{
    public PlayerSettings playerSettings;

    private bool isDragging = false;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectBubble();
        }

        if (isDragging)
        {
            Vector3 fixedWithZPosition = GetMouseWorldPosition();
            fixedWithZPosition.z = 0;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, fixedWithZPosition, playerSettings.BubbleDragSmooth);

            transform.position = smoothedPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void DetectBubble()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Bubble"))
        {
            isDragging = true;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        return cam.ScreenToWorldPoint(mousePos);
    }
}
