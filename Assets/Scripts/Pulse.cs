using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class Pulse : MonoBehaviour
{
    private bool vibration = false;
    //private List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
    public UnityEngine.XR.InputDevice right;

    /*
    void Start()
    {
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
                    right = device;
                }
            }
        }
    }
    */
    void Update()
    {
        uint channel = 0;
        float amplitude = 0.5f;
        float duration = 1.0f;
        right.SendHapticImpulse(channel, amplitude, duration);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (!vibration)
            {
                StartCoroutine("Heartbeat");
                vibration = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            StopAllCoroutines();
            vibration = false;
        }
    }

    IEnumerator Heartbeat()
    {
        Debug.Log("Vibrado");
        uint channel = 0;
        float amplitude = 0.6f;
        float duration = 0.1f;
        right.SendHapticImpulse(channel, amplitude, duration);
        yield return new WaitForSeconds(0.2f);
        right.SendHapticImpulse(channel, amplitude, duration);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Heartbeat");
    }

}
