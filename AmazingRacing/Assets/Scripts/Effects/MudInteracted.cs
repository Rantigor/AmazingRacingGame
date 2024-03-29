using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudInteracted : Interactable
{
    public float mudEffectTime;
    public GameObject Player1,Player2,_target,currentPlayer,_MudBall;
    MudBall mudBallScript;
    private void Start()
    {
        Player1 = GameObject.Find("Player 1");
        Player2 = GameObject.Find("Player 2");
    }
    public override float GetInteractableTime()
    {
        return mudEffectTime;
    }
    public override void Interacted(GameObject target)
    {
        currentPlayer = target;
        if(target.name == "Player 1")
        {
            _target = Player2;
        }else
        {
            _target = Player1;
        }
        mudBallScript =  Instantiate(_MudBall, currentPlayer.transform.position, Quaternion.identity).GetComponent<MudBall>();
        mudBallScript.mudInteracted = this;
    }

}
