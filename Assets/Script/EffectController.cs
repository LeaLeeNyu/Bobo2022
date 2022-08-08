using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _jumpParticles;
    [SerializeField] private ParticleSystem _landingParticles;
    [SerializeField] private ParticleSystem _walkingParticles;

    public void EnableWalkParticles()
    {
        _walkingParticles.Play();
    }

    public void DisableWalkParticles()
    {
        _walkingParticles.Stop();
    }

    public void EnableJumpParticles()
    {
        _jumpParticles.Play();
    }

    public void DisableJumpParticles()
    {
        _jumpParticles.Stop();
    }

    public void EnableLandingParticles()
    {
        _landingParticles.Play();
        Debug.Log("Landing");   
    }

    public void DisableLandingParticles()
    {
        _landingParticles.Stop();
    }

}
