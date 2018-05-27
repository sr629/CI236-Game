using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Objectpass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var temp = GetComponent<SpriteRenderer>();
        Debug.Log("Hello");
        temp.sortingOrder = collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var temp = GetComponent<SpriteRenderer>();
        temp.sortingOrder = 0;
    }
}
