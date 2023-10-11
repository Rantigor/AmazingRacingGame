using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    PlayerController playerController;

    public PlayerNumber playerNumber;
    KeyCode[] playerControllerKeys = new KeyCode[4];
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Start()
    {
        SetControllerKey();
    }
    //Assigns a variable according to the selected Player type
    private void SetControllerKey()
    {
        if (playerNumber == PlayerNumber.Player1)
        {
            playerControllerKeys[0] = KeyCode.W;
            playerControllerKeys[1] = KeyCode.A;
            playerControllerKeys[2] = KeyCode.S;
            playerControllerKeys[3] = KeyCode.D;
        }
        else
        {
            playerControllerKeys[0] = KeyCode.UpArrow;
            playerControllerKeys[1] = KeyCode.LeftArrow;
            playerControllerKeys[2] = KeyCode.DownArrow;
            playerControllerKeys[3] = KeyCode.RightArrow;
        }
    }


    void Update()
    {
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
