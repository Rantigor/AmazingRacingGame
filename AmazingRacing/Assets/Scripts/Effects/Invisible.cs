using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Invisible : Interactable
{
    [SerializeField] float effectTime;
    bool isInteracted = false;
    bool isInteractedEnd = false;

    GameObject _object;
    public override float GetInteractableTime()
    {
        return effectTime;
    }
    private void Update()
    {
        if (_object != null)
        {
            if (_object.GetComponent<PlayerController>().CanInteractionEnd && isInteractedEnd)
            {
                _object.GetComponent<PlayerController>().animator.SetBool("isInvinsible", false);
                _object.GetComponent<Collider2D>().isTrigger = false;
                _object.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                isInteractedEnd = false;
            }
        }
            
    }

    public override void Interacted(GameObject target)
    {
        if (isInteracted) { return; }

        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isInteracted=true;

        target.GetComponent<Animator>().SetTrigger("InvinsibleStart");
        target.GetComponent<PlayerController>().animator.SetBool("isInvinsible", true);
        target.GetComponent<Collider2D>().isTrigger = true;

        StartCoroutine(SetDefault());
        StartCoroutine(SetDefaultColor(target));

        GetObject(target);

    }
    void GetObject(GameObject obj)
    {
        _object = obj;
    }
    IEnumerator SetDefault()
    {
        yield return new WaitForSecondsRealtime(effectTime);
        isInteractedEnd=true;
    }
    IEnumerator SetDefaultColor(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(effectTime - 2);
        obj.GetComponent<PlayerController>().animator.SetTrigger("InvinsibleEnd");
    }
}
