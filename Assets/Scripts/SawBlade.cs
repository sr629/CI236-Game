﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameMaster gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        gm.KillPlayer(collision.gameObject);
       // Destroy(collision.gameObject);
    }
}
