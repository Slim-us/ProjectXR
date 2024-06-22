using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbedObjectController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        if (grabInteractable == null || rb == null)
        {
            Debug.LogError("XRGrabInteractable or Rigidbody not found on the GameObject.");
            return;
        }

        // Subscribe to the grab events
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Disable constraints when grabbed
        rb.constraints = RigidbodyConstraints.None;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // Optionally, you can re-enable constraints upon release
        // rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
