using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    
    void Start()
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();

        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.RightHanded, devices);

        foreach (var device in devices)
        {
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    float amplitude = 0.5f;
                    float duration = 1.0f;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
    }
    
    /*
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
        if (rightHandDevices[0].GetInput("grip") == 1 && hover)
        {
            held = true;
        }
        
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
    */


}
