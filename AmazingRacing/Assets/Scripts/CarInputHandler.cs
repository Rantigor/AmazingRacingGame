using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    PlayerController playerController;

    public PlayerNumber playerNumber;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    { 
        if(playerController.IsInTunnel==true){return;}
        Vector2 inputVector = Vector2.zero;
        if (playerNumber == PlayerNumber.Player1)
        {
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");
        }
        else
        {
            inputVector.x = Input.GetAxis("Horizontal Arrow");
            inputVector.y = Input.GetAxis("Vertical Arrow");
        }
        playerController.SetInputVector(inputVector);
    }
}
public enum PlayerNumber
{
    Player1,
    Player2
}
