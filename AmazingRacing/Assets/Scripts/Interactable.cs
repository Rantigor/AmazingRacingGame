using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interacted(GameObject target);
    public abstract float GetInteractableTime();
}
