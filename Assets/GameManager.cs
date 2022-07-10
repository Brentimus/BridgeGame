using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject nextLevelCanvas;
    bool flagGameover = false;
    bool nextLevel = false;
    void Start()
    {
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && flagGameover)
        {
            ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && nextLevel)
        {
            NextLevel();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        flagGameover = true;
    }

    public void ResetGame()
    {
        flagGameover = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Finish()
    {
        Time.timeScale = 0;
        nextLevelCanvas.SetActive(true);
        nextLevel = true;
    }
    public void NextLevel()
    {
        nextLevel = false;
        Time.timeScale = 1;
        nextLevelCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("11");
    }
}
