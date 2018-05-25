using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour {

    public bool switch1;
    public bool switch2;

    private Animator doorAnimator;

	// Use this for initialization
	void Start () {
        doorAnimator = GetComponent<Animator>();
    
    }
	
	// Update is called once per frame
	void Update () {
        if ( doorAnimator == null )
        {
            doorAnimator = GetComponent<Animator>();
            
        }
        if (switch1 && switch2)
        {
            doorAnimator.SetBool("Opened", true);  
        }

      
    }
}
