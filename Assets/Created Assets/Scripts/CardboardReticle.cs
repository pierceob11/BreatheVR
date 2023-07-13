using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardboardReticle : MonoBehaviour
{
    public float raycastLength = 10f; // Length of the raycast
    public LayerMask uiLayerMask; // Layer mask to filter UI objects

    private LineRenderer lineRenderer; // Reference to the LineRenderer component

    private void Start()
    {
        // Set up the LineRenderer component
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = Color.green;
    }

    private void Update()
    {
        // Get the ray from the camera center
        Ray ray = new Ray(transform.position, transform.forward);

        // Perform raycast
        if (Physics.Raycast(ray, out RaycastHit hit, raycastLength, uiLayerMask))
        {
            // Get the GameObject of the hit object
            GameObject hitObject = hit.collider.gameObject;

            // Check if the hit object has a button component
            if (hitObject.TryGetComponent<Button>(out Button button))
            {
                // Simulate a pointer click event on the button
                ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
        }

        // Update the LineRenderer's positions
        lineRenderer.SetPosition(0, ray.origin);
        lineRenderer.SetPosition(1, ray.origin + ray.direction * raycastLength);
    }
}
