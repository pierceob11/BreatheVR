using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public GameObject[] cubes;
    public Vector3[] rotationAxes;
    public float[] rotationSpeeds;

    void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.Rotate(rotationAxes[i] * rotationSpeeds[i] * Time.deltaTime);
        }
    }
}
