using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float drag = 0.5f;
    public float mass = 2.0f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public vir_joystick joystick;

    private Rigidbody thisRigidbody;

    private void Start()
    {
        thisRigidbody = gameObject.AddComponent<Rigidbody>();
        thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidbody.drag = drag;
        thisRigidbody.mass = mass;
    }
    private void FixedUpdate()
    {
        MoveVector = PoolInput();
        Move();
    }
    private void Move()
    {
        thisRigidbody.AddForce((MoveVector * speed));
    }
    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;
        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();
        if(dir.magnitude > 1)
            dir.Normalize();
        return dir;
    }
}
