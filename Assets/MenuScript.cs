using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SelectLevel;

    public void selectLevel()
    {
        MainMenu.SetActive(false);
        SelectLevel.SetActive(true);
    }

    public void backMenu()
    {
        MainMenu.SetActive(true);
        SelectLevel.SetActive(false);
    }
}
