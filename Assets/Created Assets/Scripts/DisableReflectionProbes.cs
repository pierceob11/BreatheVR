using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableReflectionProbes : MonoBehaviour
{
    void Start()
    {
        ReflectionProbe[] reflectionProbes = FindObjectsOfType<ReflectionProbe>();

        foreach (ReflectionProbe probe in reflectionProbes)
        {
            probe.enabled = false;
        }
    }
}
