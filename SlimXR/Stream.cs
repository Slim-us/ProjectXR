using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stream : MonoBehaviour
    {
        private ParticleSystem _splashParticle = null;

        private void Awake()
        {
            _splashParticle = GetComponentInChildren<ParticleSystem>();
        }

        public void Begin()
        {
            if (_splashParticle != null)
            {
                _splashParticle.Play();
            }
        }

        public void End()
        {
            if (_splashParticle != null)
            {
                _splashParticle.Stop();
            }
        }
    }
}
