﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy1;

    public GameObject enemy2;


    // Use this for initialization
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.SetActive(true);
            enemy1.SetActive(true);
            enemy2.SetActive(true);
        }

    }
   /* IEnumerator Spawn()
    {

        while (true)
        {
 
            foreach (GameObject go in enemy)
            {
                go.SetActive(true);
            }
        }
    }*/
}
