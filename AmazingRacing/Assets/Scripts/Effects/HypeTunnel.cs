using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypeTunnel : MonoBehaviour
{
    [SerializeField] float tunnelSpeed;
    [SerializeField] Transform _entry;
    [SerializeField] Transform _exit;
    [SerializeField] private GameObject Player1,Player2;
    bool canPlayer1Go, canPlayer2Go;
    
    private void Update()
    {
        HyperEffect();
    }
    void HyperEffect()
    {
        if ((Player1.transform.position - _exit.transform.position).magnitude > 1f)
        {
            if(canPlayer1Go)
            {
                Player1.transform.position = Vector3.MoveTowards(Player1.transform.position, _exit.position, tunnelSpeed * Time.deltaTime);
                Player1.GetComponent<PlayerController>().IsInTunnel = true;
            }
        }
        else
        {
            canPlayer1Go = false;
            Player1.GetComponent<PlayerController>().IsInTunnel = false;
        }


        if ((Player2.transform.position - _exit.transform.position).magnitude > 1f)
        {
            if (canPlayer2Go)
            {
                Player2.transform.position = Vector3.MoveTowards(Player2.transform.position, _exit.position, tunnelSpeed * Time.deltaTime);
                Player2.GetComponent<PlayerController>().IsInTunnel = true;
            }
        }
        else
        {
            canPlayer2Go = false;
            Player2.GetComponent<PlayerController>().IsInTunnel = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player1")
        {
            canPlayer1Go=true;
        }
        if(collision.tag == "Player2")
        { 
            canPlayer2Go=true;
        }
    }
    
}
