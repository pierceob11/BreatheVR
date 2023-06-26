using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public GameObject[] cubes;
    public float[] rotationSpeeds;

    void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            Vector3 rotationAxis = Vector3.zero;

            // Set the rotation axis based on the cube index
            if (i == 0)
                rotationAxis = Vector3.right;  // X-axis
            else if (i == 1)
                rotationAxis = Vector3.up;     // Y-axis
            else if (i == 2)
                rotationAxis = Vector3.forward; // Z-axis

            cubes[i].transform.Rotate(rotationAxis * rotationSpeeds[i] * Time.deltaTime);
        }
    }
}
