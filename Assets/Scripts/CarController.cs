using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500;
    public float rotationSpeed = 150f;

    private float movement = 0f;
    private float rotation = 0f;

    public WheelJoint2D leftWheel;
    public WheelJoint2D rightWheel;

    public Rigidbody2D rb;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            movement = -1 * speed;
            rotation = -1;
        } else
        {
            movement = -Input.GetAxisRaw("Vertical") * speed;
            rotation = Input.GetAxisRaw("Horizontal");
        }
            
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
        rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
