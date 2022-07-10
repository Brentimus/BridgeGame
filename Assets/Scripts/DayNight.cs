using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    public Volume ppv; // this is the post processing volume

    public float tick; // Increasing the tick, increases second rate
    public float seconds;
    public int days = 0;
    public int secCycle;
    [SerializeField] private float intesivityLight;
    private bool LightTint1On = true;
    private bool LightTint2On = true;

    public bool activateLights; // checks if lights are on
    public Light2D[] lights; // all the lights we want on when its dark
    public Light2D[] redBlueLights;
    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
        secCycle = 60;
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        if (seconds >= secCycle)
        {
            seconds = 0;
            days += 1;
        }
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick
        ControlPPV(); // changes post processing volume after calculation
    }

    public void ControlPPV() // used to adjust the post processing slider.
    {
        if (days % 2 == 0)
        {
            ppv.weight = (float)seconds / secCycle;
            for (int i = 0; i < lights.Length; i += 2)
            {
                lights[i].intensity = ((float)seconds / secCycle) * intesivityLight;
                if (LightTint1On)
                {
                    LightTint1On = false;
                    Invoke("LightTint1", 0.09f);
                }
            }
        }
        else
        {
            ppv.weight = 1 - (float)seconds / secCycle;
            for (int i = 0; i < lights.Length; i += 2)
            {
                lights[i].intensity = intesivityLight - ((float)seconds / secCycle) * intesivityLight;
                if (LightTint2On)
                {
                    LightTint2On = false;
                    Invoke("LightTint2", 0.09f);

                }
            }
        }
    }

    public void LightTint1()
    {
        LightTint1On = true;
        for (int i = 1; i < lights.Length; i += 2)
            lights[i].intensity = lights[i - 1].intensity + Random.Range(-0.15f, 0.15f);
    }
    public void LightTint2()
    {
        LightTint2On = true;
        for (int i = 1; i < lights.Length; i += 2)
            lights[i].intensity = lights[i - 1].intensity + Random.Range(-0.15f, 0.15f);
    }
}
