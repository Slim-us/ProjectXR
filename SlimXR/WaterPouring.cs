using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPouring : MonoBehaviour
{
    public ParticleSystem waterParticleSystem;
    private Quaternion initialRotation;
    private bool isPouring;

    private void Start()
    {
        // Store the initial rotation of the GameObject
        initialRotation = transform.rotation;

        // Ensure the Particle System is not playing at the start
        if (waterParticleSystem != null)
        {
            waterParticleSystem.Stop();
        }
    }

    private void Update()
    {
        // Calculate the angle difference between the initial and current rotations
        float angleDifference = Quaternion.Angle(initialRotation, transform.rotation);

        // Check if the angle difference is greater than or equal to 45 degrees
        if (angleDifference >= 45f)
        {
            // If not already pouring, start the Particle System
            if (!isPouring)
            {
                StartPouring();
            }
        }
        else
        {
            // If currently pouring, stop the Particle System
            if (isPouring)
            {
                StopPouring();
            }
        }
    }

    private void StartPouring()
    {
        if (waterParticleSystem != null)
        {
            waterParticleSystem.Play();
            isPouring = true;
        }
    }

    private void StopPouring()
    {
        if (waterParticleSystem != null)
        {
            waterParticleSystem.Stop();
            isPouring = false;
        }
    }
}
