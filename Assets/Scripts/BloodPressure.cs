using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPressure : MonoBehaviour
{
    //I need the bool onArm to tell if the user is hovering over an arm, and the location transform is to transfer the location from the onTriggerEnter() function to the letGo() function
    public bool onArm = false;
    private Transform location;

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

    //This function is run by the XR Grab Interactable script when the VR controller no longer is holding the blood pressure cuff.
    public void letGo()
    {
        if (onArm)
        {
            this.transform.position = location.position;
            this.transform.rotation = location.rotation;
        }
    }
}
