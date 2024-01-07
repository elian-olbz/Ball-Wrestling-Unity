using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cam : MonoBehaviour
{
    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //target = GameObject.Find("AtomBall").transform;
    }

    void Update()
    {
        transform.position = target.position; 
    }
}
