using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControl : MonoBehaviour
{
    public Transform active1;
    public Transform active2;
    private float sec = 0;
    public float speed = 1;
    bool flag = true;

    void Update()
    {
        if (flag)
        {
            sec += Time.fixedDeltaTime * speed;
            Debug.Log(sec);
            if (sec > 50)
                flag = false;
        }
            else
        {
            //sec = Time.fixedDeltaTime * speed;
            if (sec <= 0)
                flag = true;
        }
        
        active1.transform.Rotate(0, 0, sec);
        active2.transform.Rotate(0, 0, -sec);
    }
}
