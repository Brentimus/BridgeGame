using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500;

    private float movement = 0f;

    public WheelJoint2D leftWheel;
    public WheelJoint2D rightWheel;

    private void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        if (movement == 0f)
        {
            leftWheel.useMotor = false;
            rightWheel.useMotor = false;
        } 
        else
        {
            leftWheel.useMotor = true;
            rightWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            leftWheel.motor = motor;
            rightWheel.motor = motor;
        }
    }
}
