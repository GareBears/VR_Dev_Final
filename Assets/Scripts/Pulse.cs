using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    //I will attempt to use the vibrating motors in the oculus quest controllers
    //None of this works because XRController isn't a thing :<
    /*
    private XRController xr;

    void Start()
    {
        //xr = (XRController)GameObject.FindObjectOfType(typeof(XRController));
        xr = GetComponent<XRController>();
        xr.SendHapticImpulse(0.7f, 2f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            StartCoroutine("Heartbeat");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            StopCoroutine("Heartbeat");
        }
    }

    IEnumerator Heartbeat()
    {
        yield return new WaitForSeconds(1f);
    }
    */
}
