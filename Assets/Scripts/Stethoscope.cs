using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    //This is the variable controller audio
    public AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stethoscope")){
            audio.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stethoscope"))
        {
            audio.Stop();
        }
    }
}
