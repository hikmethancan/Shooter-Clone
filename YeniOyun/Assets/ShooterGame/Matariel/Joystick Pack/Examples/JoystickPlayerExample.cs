using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public FixedJoystick variableJoystick;
    public Rigidbody rb;
    public float speed;

    public void FixedUpdate()
    {
        float angle = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg;
        if(angle!=0){
        angle = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.y, angle, speed);
        transform.rotation = Quaternion.Euler(0,angle,0);
        }
    }
}