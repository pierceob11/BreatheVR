using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterG : MonoBehaviour
{
    public GameObject planePrefab;  // The prefab for the plane object
    public int startX;              // Starting X value for the grid
    public int endX;                // Ending X value for the grid
    public int startZ;              // Starting Z value for the grid
    public int endZ;                // Ending Z value for the grid

    void Start()
    {
        InitializeGrid();
    }

    void InitializeGrid()
    {
        for (int x = startX; x <= endX; x++)
        {
            for (int z = startZ; z <= endZ; z++)
            {
                // Calculate the position for each plane object
                Vector3 position = new Vector3(x, 0f, z);

                // Instantiate the plane prefab at the calculated position
                GameObject planeObject = Instantiate(planePrefab, position, Quaternion.identity);
                planeObject.transform.SetParent(transform);
            }
        }
    }
}
