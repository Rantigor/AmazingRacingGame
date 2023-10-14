using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractedWithInteractable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>() != null)
        {
            collision.GetComponent<Interactable>().Interacted(gameObject);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<SpriteRenderer>().enabled = false;

            Destroy(collision.gameObject, collision.GetComponent<Interactable>().GetInteractableTime() + .01f);
        }
    }
}