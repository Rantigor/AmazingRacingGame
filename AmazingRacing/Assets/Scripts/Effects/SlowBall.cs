using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlowBall : MonoBehaviour
{
    [SerializeField] float moveSpeed = .5f;
    [SerializeField] byte changeTransparan;
    [SerializeField] float slowAmount;

    public SlowEnemy slowEnemy;
    public Image player1SnowUI, player2SnowUI;

    private float defaultSpeed;
    PlayerController playerController;
    private void Start()
    {
        player1SnowUI = GameObject.Find("SnowP1").GetComponent<Image>();
        player2SnowUI = GameObject.Find("SnowP2").GetComponent<Image>();
    }
    void Update()
    {
        if (slowEnemy == null) return;

        transform.position = Vector3.MoveTowards(transform.position, slowEnemy._target.transform.position, moveSpeed);
        Vector3 Look = transform.InverseTransformPoint(slowEnemy._target.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg + 150;
        transform.Rotate(0, 0, Angle);

        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            Invoke("ChangeColorTransparan", 2);
        }
    }
    void ChangeColorTransparan()
    {
        if (player1SnowUI.enabled == true)
        {
            player1SnowUI.color -= new Color32(0, 0, 0, changeTransparan);
        }
        if (player2SnowUI.enabled == true)
        {
            player2SnowUI.color -= new Color32(0, 0, 0, changeTransparan);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == slowEnemy._target.name)
        {
            playerController = collision.GetComponent<PlayerController>();
            defaultSpeed = playerController.accelerationFactor;
            player1SnowUI.color = new Color32(255, 255, 255, 150);
            player2SnowUI.color = new Color32(255, 255, 255, 150);
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            playerController.accelerationFactor -= slowAmount;
            if (slowEnemy._target.name == "Player 1")
            {
                player1SnowUI.enabled = true;
            }
            else
            {
                player2SnowUI.enabled = true;
            }
            StartCoroutine(CloseSnowUI());
        }
    }
    IEnumerator CloseSnowUI()
    {
        yield return new WaitForSecondsRealtime(slowEnemy.slowEffectTime + 0.1f);
        if (slowEnemy._target.name == "Player 1")
        {
            player1SnowUI.enabled = false;
        }
        else
        {
            player2SnowUI.enabled = false;
        }
        playerController.accelerationFactor = defaultSpeed;
        Destroy(gameObject);
    }
}
