using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MudBall : MonoBehaviour
{
    [SerializeField] float moveSpeed = .5f;
    [SerializeField] byte changeTransparan;
    public MudInteracted mudInteracted;

    public Image player1MudUI, player2MudUI;
    bool canGo;
    private void Start()
    {
        player1MudUI = GameObject.Find("MudP1").GetComponent<Image>();
        player2MudUI = GameObject.Find("MudP2").GetComponent<Image>();
    }
    void Update()
    {
        if(mudInteracted != null) { canGo = true; }
        if(canGo)
        {
            transform.position = Vector3.MoveTowards(transform.position,mudInteracted._target.transform.position,moveSpeed);
            Vector3 Look = transform.InverseTransformPoint(mudInteracted._target.transform.position);
            float Angle = Mathf.Atan2(Look.y,Look.x) * Mathf.Rad2Deg + 150;
            transform.Rotate(0,0, Angle);
        }
        if(gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            Invoke("ChangeColorTransparan", 2);
        }
    }
    void ChangeColorTransparan()
    {
        if (player1MudUI.enabled == true)
        {
            player1MudUI.color -= new Color32(0, 0, 0, changeTransparan);
        }
        if(player2MudUI.enabled == true)
        {
            player2MudUI.color -= new Color32(0, 0, 0, changeTransparan);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == mudInteracted._target.name)
        {
            player1MudUI.color = new Color32(255, 255, 255, 255);
            player2MudUI.color = new Color32(255, 255, 255, 255);
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (mudInteracted._target.name == "Player 1")
            {
                player1MudUI.enabled = true;
            }
            else
            {
                player2MudUI.enabled = true;
            }
            StartCoroutine(CloseMudUI());
        }
    }
    IEnumerator CloseMudUI()
    {
        yield return new WaitForSecondsRealtime(mudInteracted.mudEffectTime +0.1f);
        if (mudInteracted._target.name == "Player 1")
        {
            player1MudUI.enabled = false;
        }
        else
        {
            player2MudUI.enabled = false;
        }
        Destroy(gameObject);
    }
}
