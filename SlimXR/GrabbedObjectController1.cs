using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbedObjectController1 : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private MeshCollider meshCollider;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        meshCollider = GetComponent<MeshCollider>();

        if (grabInteractable == null || rb == null || meshCollider == null)
        {
            Debug.LogError("XRGrabInteractable, Rigidbody, or MeshCollider not found on the GameObject.");
            return;
        }

        // Subscribe to the grab events
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Make Rigidbody non-kinematic when grabbed
        rb.isKinematic = false;

        // Make Mesh Collider convex when grabbed
        meshCollider.convex = true;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // This part is optional, you can leave the Rigidbody and Mesh Collider as is upon release
        // rb.isKinematic = true;
        // meshCollider.convex = false;
    }
}
