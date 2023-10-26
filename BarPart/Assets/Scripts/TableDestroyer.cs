using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDestroyer : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Luqid"))
        {
            Destroy(collision.gameObject, 5);
            gameManager.discontent += 0.005f;
        }
            
    }
}
