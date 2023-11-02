using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomEffect : Interactable
{
    public List<GameObject> allEffects;
    public GameObject currentEffect;
    private void Start()
    {
        currentEffect = allEffects[UnityEngine.Random.Range(0,allEffects.Count)];
    }
    public override void Interacted(GameObject target)
    {
        Instantiate(currentEffect.GetComponent<Interactable>()).Interacted(target);
    }

    public override float GetInteractableTime()
    {
        return currentEffect.GetComponent<Interactable>().GetInteractableTime();
    }
}
