using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractedWithInteractable : MonoBehaviour
{
    PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>() != null)
        {
            collision.GetComponent<Interactable>().Interacted(gameObject);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<SpriteRenderer>().enabled = false;
            playerController = collision.GetComponent<PlayerController>();


        }
    }
    private void Update()
    {
        if(playerController != null)
        {
            if (gameObject.GetComponent<PlayerController>().CanInteractionEnd)
            {
                Invoke("DestroyObject", playerController.GetComponent<Interactable>().GetInteractableTime() + .2f);
            }
            else
            {
                CancelInvoke("DestroyObject");
            }
        }
    }
    void DestroyObject()
    {
        Destroy(playerController.gameObject);
    }
}