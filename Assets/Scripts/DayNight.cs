using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNight : MonoBehaviour
{
    public Volume ppv;

    public float tick;
    public float seconds;
    public int days = 0;
    public int secCycle;

    public bool activateLights;
    public GameObject[] lights;

    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
        secCycle = 15;
    }

    void FixedUpdate() 
    {
        CalcTime();
    }

    public void CalcTime()
    {
        if (seconds >= secCycle)
        {
            seconds = 0;
            days += 1;
        }
        seconds += Time.fixedDeltaTime * tick;
        ControlPPV();
    }

    public void ControlPPV()
    {
        if (days % 2 == 0)
        {
            ppv.weight = (float)seconds / secCycle;
            for (int i = 0; i < lights.Length; i ++)
            {
                if (ppv.weight > 0.75)
                    lights[i].SetActive(true);
            }
        }
        else
        {
            ppv.weight = 1 - (float)seconds / secCycle;
            for (int i = 0; i < lights.Length; i ++)
            {
                if(ppv.weight < 0.7)
                    lights[i].SetActive(false);
            }
        }
    }
}
