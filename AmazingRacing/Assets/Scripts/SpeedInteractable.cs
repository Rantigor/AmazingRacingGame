using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedInteractable : MonoBehaviour, Interactable
{
    [SerializeField] float speedChange;
    [SerializeField] float interactableTime;

    private float defaultSpeed;
    private void Start()
    {
        defaultSpeed = FindObjectOfType<PlayerController>().accelerationFactor;
    }
    enum InteractableType { Up, Down }
    [SerializeField]InteractableType IType;

    public void Interacted(PlayerController playerController)
    {
        switch(IType)
        {
            case InteractableType.Up:
                playerController.accelerationFactor += speedChange;
                break;
            case InteractableType.Down:
                playerController.accelerationFactor -= speedChange;
                break;
        }
        StartCoroutine(SetDefault(playerController));
    }
    IEnumerator SetDefault(PlayerController pCont)
    {
        yield return new WaitForSecondsRealtime(interactableTime);
        pCont.accelerationFactor = defaultSpeed;
    }
}
