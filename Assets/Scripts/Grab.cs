using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform pos;
    public bool hover = false;
    public bool held = false;
    public Mesh grabMesh;
    public Mesh nonGrabMesh;
    public Material grabMat;
    public Material nonGrabMat;
    public float xRotOffset;
    public float yRotOffset;
    public float zRotOffset;

    void FixedUpdate()
    {
        

        List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        foreach (var device in rightHandDevices)
        {
            bool triggerValue;
            device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue);
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
            this.transform.rotation = pos.rotation * Quaternion.Euler(new Vector3(xRotOffset, yRotOffset, zRotOffset));
            if (grabMesh != null)
            {
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = grabMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = grabMat;
            }
        }
        else
        {
            if (nonGrabMesh != null)
            {
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = nonGrabMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = nonGrabMat;
            }
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
