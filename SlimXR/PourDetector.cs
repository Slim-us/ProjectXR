using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ParticleSystemOnGrab : MonoBehaviour
{
    public ParticleSystem waterParticleSystem;
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null || waterParticleSystem == null)
        {
            Debug.LogError("XRGrabInteractable or Particle System not found on the GameObject.");
            return;
        }

        // Subscribe to the grab events
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Start the Particle System when grabbed
        if (waterParticleSystem != null)
        {
            waterParticleSystem.Play();
        }
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // Stop the Particle System when released
        if (waterParticleSystem != null)
        {
            waterParticleSystem.Stop();
        }
    }
}
