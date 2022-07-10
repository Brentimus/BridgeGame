using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ChangeScene(int level)
    {
        if (PlayerPrefs.GetInt("DLC") == 1)
            SceneManager.LoadScene(level + 3);
        else
            SceneManager.LoadScene(level);
    }
}
