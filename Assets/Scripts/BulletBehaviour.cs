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
        if (other.gameObject.layer == 2)
        {
            Physics2D.IgnoreLayerCollision(other.gameObject.GetComponent<SpriteRenderer>().sortingLayerID, gameObject.GetComponent<SpriteRenderer>().sortingLayerID, true);
        }
        if (other.gameObject.tag == "Enemy")
        {

            GameObject expl = Instantiate(explosion, other.transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(other.gameObject);
            Destroy(expl,0.3f);
        }
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
