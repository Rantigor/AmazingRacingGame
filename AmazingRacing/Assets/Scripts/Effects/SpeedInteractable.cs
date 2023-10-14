using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedInteractable : Interactable
{
    [SerializeField] float speedChange;
    [SerializeField] float interactableTime;

    private float defaultSpeed;
    bool isInteracted = false;
    enum InteractableType { Up, Down }
    [SerializeField]InteractableType IType;

    private void Start()
    {
        defaultSpeed = FindObjectOfType<PlayerController>().accelerationFactor;
    }

    public override void Interacted(GameObject target)
    {
        if(isInteracted) { return; }
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        isInteracted = true;
        
        PlayerController playerController = target.GetComponent<PlayerController>();
        
        StartCoroutine(SetDefault(playerController));
        
        switch (IType)
        {
            case InteractableType.Up:
                playerController.accelerationFactor += speedChange;
                break;
            case InteractableType.Down:
                playerController.accelerationFactor -= speedChange;
                break;
        }
        Destroy(gameObject, GetComponent<Interactable>().GetInteractableTime() + .01f);
    }
    IEnumerator SetDefault(PlayerController pCont)
    {
        yield return new WaitForSecondsRealtime(interactableTime);
        switch (IType)
        {
            case InteractableType.Up:
                pCont.accelerationFactor -= speedChange;
                break;
            case InteractableType.Down:
                pCont.accelerationFactor += speedChange;
                break;
        }
    }

    public override float GetInteractableTime()
    {
        return interactableTime;
    }
}
