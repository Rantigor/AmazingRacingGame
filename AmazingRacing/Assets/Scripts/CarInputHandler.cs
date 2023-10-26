using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            if(Input.GetKey(KeyCode.A))
            {
                inputVector.x = -1;
            }
            else if(Input.GetKey(KeyCode.D))
            {
                inputVector.x = 1;
            }

            if(Input.GetKey(KeyCode.W))
            {
                inputVector.y = 1;
            }
            else if( Input.GetKey(KeyCode.S))
            {
                inputVector.y = -1;
            }
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
