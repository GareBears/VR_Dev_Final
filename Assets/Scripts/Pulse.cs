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
                    float amplitude = 1f;
                    float duration = 0.1f;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
        yield return new WaitForSeconds(0.78f);
        StartCoroutine("Heartbeat");
    }

}