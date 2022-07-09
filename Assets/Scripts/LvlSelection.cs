using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlSelection : MonoBehaviour
{
    public Button[] lvlBtn;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlBtn.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlBtn[i].interactable = false;
        }
    }

}
