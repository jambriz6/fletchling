using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectInspector : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 previousMousePosition;
    private Quaternion originalRotation;
    private float rotationSpeed = 0.5f;
    private float returnSpeed = 5f; // Speed at which the object returns to original rotation

    void Start()
    {
        // Record the original rotation of the object
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform raycast to check if the object is clicked
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    previousMousePosition = Input.mousePosition;
                }
            }
        }

        // Rotate the object if dragging
        if (isDragging && Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseOffset = currentMousePosition - previousMousePosition;

            // Rotate around vertical axis (Y-axis)
            transform.Rotate(Vector3.up, -mouseOffset.x * rotationSpeed, Space.World);

            // Rotate around horizontal axis (X-axis)
            transform.Rotate(Vector3.right, mouseOffset.y * rotationSpeed, Space.World);

            previousMousePosition = currentMousePosition;
        }

        // Release dragging
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            // Smoothly interpolate back to original rotation
            StartCoroutine(ReturnToOriginalRotation());
        }
    }

    IEnumerator ReturnToOriginalRotation()
    {
        float t = 0f;
        Quaternion currentRotation = transform.rotation;

        while (t < 1f)
        {
            t += Time.deltaTime * returnSpeed;
            transform.rotation = Quaternion.Lerp(currentRotation, originalRotation, t);
            yield return null;
        }

        // Ensure exact original rotation
        transform.rotation = originalRotation;
    }
}
