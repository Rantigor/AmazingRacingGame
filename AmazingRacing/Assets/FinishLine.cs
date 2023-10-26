using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            SceneManager.LoadScene("Player1Win");
        }
        if (collision.tag == "Player2")
        {
            SceneManager.LoadScene("Player2Win");
        }
    }
}
