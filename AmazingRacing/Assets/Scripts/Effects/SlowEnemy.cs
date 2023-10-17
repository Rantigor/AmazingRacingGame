using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : Interactable
{
    public float slowEffectTime;
    public GameObject Player1, Player2, _target, currentPlayer, slowBall;
    SlowBall _slowBall;


    private void Start()
    {
        Player1 = GameObject.Find("Player 1");
        Player2 = GameObject.Find("Player 2");
    }
    public override float GetInteractableTime()
    {
        return slowEffectTime;
    }

    public override void Interacted(GameObject target)
    {
        currentPlayer = target;
        if (target.name == "Player 1")
        {
            _target = Player2;
        }
        else
        {
            _target = Player1;
        }
        _slowBall = Instantiate(slowBall, currentPlayer.transform.position, Quaternion.identity).GetComponent<SlowBall>();
        _slowBall.slowEnemy = this;
    }

}
