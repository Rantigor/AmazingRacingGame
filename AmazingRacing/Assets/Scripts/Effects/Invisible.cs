using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : Interactable
{
    [SerializeField] float effectTime;
    bool isInteracted = false;
    public override float GetInteractableTime()
    {
        return effectTime;
    }

    public override void Interacted(GameObject target)
    {
        if (isInteracted) { return; }

        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isInteracted=true;

        target.GetComponent<Collider2D>().isTrigger = true;
        StartCoroutine(SetDefault(target));
    }
    IEnumerator SetDefault(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(effectTime);
        obj.GetComponent<Collider2D>().isTrigger = false;
    }
}
