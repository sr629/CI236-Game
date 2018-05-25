using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    private float timer;
    public int bulletLife = 4;
    public GameObject explosion;
    public GameObject bulletExplosion;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Target")
        {

            other.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            Destroy(gameObject);

        }
         
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
