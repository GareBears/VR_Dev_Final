using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform pos;
    public bool hover = false;
    public bool held = false;
    public float yOffset;
    public float xOffset;
    public float zOffset;
    public Mesh grabMesh;
    public Mesh nonGrabMesh;
    public Material grabMat;
    public Material nonGrabMat;

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
            this.transform.position = new Vector3(pos.position.x + xOffset, pos.position.y + yOffset, pos.position.z + zOffset);
            this.transform.rotation = pos.rotation;
            if (grabMesh != null)
            {
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = grabMesh;
            }
        }
        else
        {
            if (nonGrabMesh != null)
            {
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = nonGrabMesh;
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
