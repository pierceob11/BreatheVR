using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingSystem : MonoBehaviour
{
    public ParticleSystem inhaleParticles;
    public ParticleSystem exhaleParticles;
    public float particleOnTime = 2f;  // Time the particle systems are turned on for
    public float waitTime = 5f;  // Public wait time between alternation of particle systems

    private bool isBreathing = false;

    private void Start()
    {
        StartCoroutine(BreathingRoutine());
    }

    private IEnumerator BreathingRoutine()
    {
        while (true)
        {
            // Enable inhale particles
            inhaleParticles.Play();
            exhaleParticles.Stop();

            isBreathing = true;
            yield return new WaitForSeconds(particleOnTime);

            // Enable exhale particles
            inhaleParticles.Stop();
            exhaleParticles.Play();

            isBreathing = false;
            yield return new WaitForSeconds(particleOnTime);

            // Wait for the specified wait time before repeating the breathing cycle
            yield return new WaitForSeconds(waitTime);
        }
    }
}