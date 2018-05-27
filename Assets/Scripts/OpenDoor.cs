using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{


    public bool puzzleSolved;
    private Animator animator;
    private Door doorScript;
    private Animator animatorSwitch;
    // Use this for initialization
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        doorScript = GetComponentInParent<Door>();
        animatorSwitch = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && puzzleSolved)
        {
            doorScript.switch1 = true;
            animatorSwitch.SetBool("Switch", true);
        }

    }
}
