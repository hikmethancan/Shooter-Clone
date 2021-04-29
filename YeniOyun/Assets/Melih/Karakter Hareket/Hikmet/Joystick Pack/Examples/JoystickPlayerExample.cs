using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public FixedJoystick variableJoystick;
    public Rigidbody rb;
    public float rotateVertical;
    public float rotateHorizontal;
    public float speed;

    public void FixedUpdate()
    {
        float angle = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg;
        rotateHorizontal = variableJoystick.Horizontal * -1f;
        rotateVertical = variableJoystick.Vertical * 1f;
        transform.Rotate(0, angle * speed, 0);

    }
}