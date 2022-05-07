using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPressure : MonoBehaviour
{
    //I need the bool onArm to tell if the user is hovering over an arm, and the location transform is to transfer the location from the onTriggerEnter() function to the letGo() function
    public bool onArm = false;
    private Transform location;
    public Mesh attached;
    public Material attach;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioSource audio;

    void Update()
    {
        if (this.gameObject.GetComponent<Grab>().held != true)
        {
            if (onArm)
            {
                this.transform.position = location.position;
                this.transform.rotation = location.rotation;
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = attached;
                this.gameObject.GetComponent<MeshRenderer>().material = attach;
                StartCoroutine("Inflate");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //If the other object is an arm, onArm is set to true and the location is set to where the cuff should go.
        if (other.CompareTag("Arm"))
        {
            onArm = true;
            location = other.gameObject.GetComponent<Arm>().BloodPressurePos;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            if (onArm)
            {
                onArm = false;
            }
        }
    }

    IEnumerator Inflate()
    {

    }
}
