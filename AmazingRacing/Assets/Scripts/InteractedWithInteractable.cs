using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractedWithInteractable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>() != null)
        {
            collision.GetComponent<Interactable>().Interacted(gameObject.GetComponent<PlayerController>());
        }
    }
}