using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    private float timer;
    public int bulletLife = 4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += 1.0F * Time.deltaTime;

        if (timer >= bulletLife)
        {
            GameObject.Destroy(gameObject);
        }

    }

    void OnCollisionEnter()
    {
        GameObject.Destroy(gameObject);
    }
}
