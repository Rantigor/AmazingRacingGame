using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    float particleEmissionRate = 0;

    PlayerController playerController;

    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;
    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        //Get the particle system
        particleSystemSmoke = GetComponent<ParticleSystem>();
        //Get the emission component
        particleSystemEmissionModule = particleSystemSmoke.emission;
        //Set it to zero emission.
        particleSystemEmissionModule.rateOverTime = 0;

    }
    void Start()
    {

    }


    void Update()
    {
        //Reduce the particles over time.
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5);
        particleSystemEmissionModule.rateOverTime = particleEmissionRate;

        if (playerController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            //If the car tires are screeching then we'll emitt smoke. If the player is braking then emitt a lot of smoke
            if (isBraking)
                particleEmissionRate = 30;
            //If the player is drifting we'll emitt smoke based on how much player is drifting
            else particleEmissionRate = Mathf.Abs(lateralVelocity) * 2;
        }
    }
}
