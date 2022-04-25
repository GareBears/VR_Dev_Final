using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform pos;
    public bool hover = false;
    public bool held = false;

    void FixedUpdate()
    {
        List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        foreach (var device in rightHandDevices)
        {
            bool triggerValue;
            device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue);
            if (triggerValue)
            {
                held = true;
            }
            else
            {
                held = false;
            }
        }

        if (held && hover)
        {
            this.transform.position = pos.position;
            this.transform.rotation = pos.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            hover = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            hover = false;
        }
    }

}
