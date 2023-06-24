using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingSystem : MonoBehaviour
{
    public ParticleSystem inhale;
    public ParticleSystem exhale;
    public float waitTimer = 2.0f;
    public float playTimer = 3.5f;

    private bool isPlaying = false;
    private bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Enable Inhale system
        inhale.Play();
        Debug.Log("Playing inhale");

        WaitWhileItPlays(); //Waiting for inhale to finish

        inhale.Stop();
        Debug.Log("Stopping inhale");

        WaitBeforeNextBreath();

        exhale.Play();

        WaitWhileItPlays();

        exhale.Stop();


    }


    System.Collections.IEnumerator WaitBeforeNextBreath()
    {

        // Wait for the specified wait time
    yield return new WaitForSeconds(waitTimer);
        }


    System.Collections.IEnumerator WaitWhileItPlays()
    {

        // Wait for the specified wait time
        yield return new WaitForSeconds(playTimer);

      
       
    }


}
