using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {
    
    private float timeOn;
    public float maxTime = 1;
    private bool OnOff;
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - timeOn > maxTime)
        {
            OnOff = false;
        }
		if (this.name == "Switch1")
        {
            GetComponentInParent<LockScript>().switch1 = OnOff;
        }
        if( this.name == "Switch2")
        {
            GetComponentInParent<LockScript>().switch2 = OnOff;
        }
        animator.SetBool("Switch", OnOff);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player" )
        {
            OnOff = true;
            timeOn = Time.time;
        }
       
    }
}
