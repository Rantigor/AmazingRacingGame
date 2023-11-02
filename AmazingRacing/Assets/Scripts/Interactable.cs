using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interacted(GameObject target);
    public abstract float GetInteractableTime();
}
