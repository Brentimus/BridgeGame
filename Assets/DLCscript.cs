using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCscript : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("DLC", 0);
    }
    public void dlcSwitcher(bool newValue)
    {
        if (newValue)
            PlayerPrefs.SetInt("DLC", 1);
        else
            PlayerPrefs.SetInt("DLC", 0);

        Debug.Log(newValue);
    }
}
