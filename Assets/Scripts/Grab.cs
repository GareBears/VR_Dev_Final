using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform pos;
    public bool hover = false;
    public bool held = false;
    public List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();

    void Start()
    {
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
    }

    void Update()
    {
        /*
        if (rightHandDevices[0].GetAxis("grip") == 1 && hover)
        {
            held = true;
        }
        */
        if (held)
        {
            this.transform.position = pos.position;
            this.transform.rotation = pos.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hand"))
        {
            hover = true;
            pos.position = other.transform.position;
            pos.rotation = other.transform.rotation;
        }
    }


}
