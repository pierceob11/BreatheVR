using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGridInitializer : MonoBehaviour
{
    public GameObject planePrefab;  // The prefab for the plane object
    public int minX;               // Minimum value for the X-axis
    public int minZ;               // Minimum value for the Z-axis
    public int maxX;               // Maximum value for the X-axis
    public int maxZ;               // Maximum value for the Z-axis

    void Start()
    {
        InitializeGrid();
    }

    void InitializeGrid()
    {
        MeshRenderer planeRenderer = planePrefab.GetComponent<MeshRenderer>();
        float spacing = planeRenderer.bounds.size.z;

        Vector3 initialPosition = new Vector3(minX, transform.position.y, minZ);
        int planeCount = 0;
        List<GameObject> placedPlanes = new List<GameObject>();

        for (int x = minX; x <= maxX; x++)
        {
            for (int z = minZ; z <= maxZ; z++)
            {
                // Calculate the position for each plane object with the calculated spacing
                Vector3 position = new Vector3(initialPosition.x + (x * spacing), initialPosition.y, initialPosition.z + (z * spacing));

                // Instantiate the plane prefab at the calculated position
                GameObject planeObject = Instantiate(planePrefab, position, Quaternion.identity);
                planeObject.transform.SetParent(transform);

                // Randomly choose rotation on the y-axis
                float randomRotation = Random.Range(0, 4) * 90f;
                planeObject.transform.rotation = Quaternion.Euler(0f, randomRotation, 0f);

                placedPlanes.Add(planeObject);
                planeCount++;
            }
        }
        Debug.Log("Number of planes placed: " + planeCount);

        // Increase scale of each placed prefab on the X and Z axes to 1.5
        foreach (GameObject placedPlane in placedPlanes)
        {
            Vector3 currentScale = placedPlane.transform.localScale;
            Vector3 newScale = new Vector3(currentScale.x * 1.5f, currentScale.y, currentScale.z * 1.5f);
            placedPlane.transform.localScale = newScale;
        }
    }
}