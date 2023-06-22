using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainController : MonoBehaviour
{
    [Range(0, 1f)]
    [SerializeField] private float masterIntensity = 1f;

    [Range(0, 1f)]
    [SerializeField] private float rainIntensity = 1f;

    [SerializeField] private bool autoUpdate;

    public ParticleSystem rainPart;

    private ParticleSystem.EmissionModule rainEmission;
    private ParticleSystem.ForceOverLifetimeModule rainForce;

    void Awake()
    {
        rainEmission = rainPart.emission;
        rainForce = rainPart.forceOverLifetime;
        UpdateAll();
    }

    void Update()
    {
        if (autoUpdate)
            UpdateAll();
    }

    void UpdateAll(){
        rainEmission.rateOverTime = 200f * masterIntensity * rainIntensity;
        rainForce.x = new ParticleSystem.MinMaxCurve(-25f * 1 * masterIntensity, (-3-30f * 1) * masterIntensity);
    }
    
    public void OnRainChanged(float value)
    {
        rainIntensity = value;
        UpdateAll();
    }
}
