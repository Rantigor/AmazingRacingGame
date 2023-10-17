using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudInteracted : Interactable
{
    public float mudEffectTime;
    public GameObject Player1,Player2,_target,currentPlayer,MudBall;
    MudBall mudBallScript;
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
            currentPlayer = Player1;
        }
        mudBallScript =  Instantiate(MudBall, currentPlayer.transform.position, Quaternion.identity).GetComponent<MudBall>();
        mudBallScript.mudInteracted = this;
    }

}
