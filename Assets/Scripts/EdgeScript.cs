using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeScript : MonoBehaviour {


    private float lastCollision;
    private bool edgeCollision; 
    private DashScript dashScript;
	// Use this for initialization
	void Start () {
        dashScript = GameObject.FindGameObjectWithTag("Player").GetComponent<DashScript>();

    }
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        lastCollision = Time.time;
        Debug.Log("Enter");
        if ( dashScript.isDashing == true)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Staying");
        if (Time.time - lastCollision > 0.5)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
