using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class Pulse : MonoBehaviour
{
    public XRController xr1;
    public XRController xr2;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand1"))
        {
            StartCoroutine("HeartbeatR");
        }else if (other.CompareTag("Hand2"))
        {
            StartCoroutine("HeartbeatL");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand1") || other.CompareTag("Hand2"))
        {
            StopAllCoroutines();
        }

    }

    IEnumerator HeartbeatR()
    {
        xr1.SendHapticImpulse(0.5f, 0.1f);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator HeartbeatL()
    {
        //xr.gameObject.GetComponentInParent<XRController>().SendHapticImpulse(0.7f, 2f);
        yield return new WaitForSeconds(1f);
    }
}
