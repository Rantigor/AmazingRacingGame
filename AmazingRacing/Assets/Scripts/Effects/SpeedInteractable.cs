using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedInteractable : Interactable
{
    float speedChange = 40;
    [SerializeField] float interactableTime;

    bool isInteracted = false;
    enum InteractableType { Up, Down }
    [SerializeField]InteractableType IType;

    GameManager gameManager;
    float timer;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        yield return new WaitForSeconds(interactableTime);
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
