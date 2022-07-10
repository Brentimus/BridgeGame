using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource gameoverAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grounder"))
        {
            gameoverAudio.Play();
            gameManager.GameOver();
        }
    }
}
