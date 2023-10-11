using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrailerRendererHandler : MonoBehaviour
{
    PlayerController playerController;
    TrailRenderer trailRenderer;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        trailRenderer = GetComponentInParent<TrailRenderer>();
        trailRenderer.emitting = false;
    }

    void Start()
    {
        
    }
    void Update()
    {
        if(playerController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
            trailRenderer.emitting = true;
        else
            trailRenderer.emitting = false;
    }
}
