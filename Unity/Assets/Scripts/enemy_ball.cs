using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ball : MonoBehaviour
{
    private Transform target;
    public float speed = 0.7f;
    public float drag = 3.0f;
    public float mass = 1.7f;

    private Vector3 speedRot = (Vector3.left) * 90f;

    private Rigidbody thisRigidbody;

    void Start()
    {
        thisRigidbody = gameObject.AddComponent<Rigidbody>();
        thisRigidbody.drag = drag;
        thisRigidbody.mass = mass;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    void FixedUpdate()
    {
        transform.Rotate(speedRot * Time.deltaTime * 1.5f);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
