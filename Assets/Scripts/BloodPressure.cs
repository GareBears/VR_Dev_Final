using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPressure : MonoBehaviour
{
    public bool onArm = false;
    private Transform location;

    void OnTriggerEnter(Collider other)
    {
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

    public void letGo()
    {
        if (onArm)
        {
            this.transform.position = location.position;
            this.transform.rotation = location.rotation;
        }
    }
}
