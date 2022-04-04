using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    //This is the script allowing the stethoscope to play heartbeat sounds when hovering over the heart.
    
    //This is the variable controlling audio on the heart.
    public AudioSource audio;

    //This function checks when a trigger interacts with a collider.
    void OnTriggerEnter(Collider other)
    {
        //To check if it is the correct object that we are hovering over, I used CompareTag() which compares the tag of an object to the input and returns a boolean value.
        //If so, the audio is set to play.
        if (other.CompareTag("Stethoscope")){
            audio.Play();
        }
    }

    //This function triggers when the trigger stops interacting with a collider.
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stethoscope"))
        {
            audio.Stop();
        }
    }
}
