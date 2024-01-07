using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Health : MonoBehaviour
{
    public float health;
    private float max_hp;
    public Slider slider;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        max_hp = health;
    }
 
    void Update()
    {
        slider.value = health;
    }
    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "wall")
        {
            source.Play();
            if(health > 0)
                health -= 5.0f;
        }
        else if(obj.gameObject.tag == "floor")
        {
            source.Play();
            health = 0f;
        }
        else if(obj.gameObject.tag == "enemy" || obj.gameObject.tag == "arena")
            source.Play();
    }
    public float getHealth()
    {
        return health;
    }
    public void resetHealth()
    {
        health = max_hp;
    }
}
