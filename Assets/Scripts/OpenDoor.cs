using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{


    public bool puzzleSolved;
    private Animator animator;
    private Animator animatorSwitch;
    // Use this for initialization
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        animatorSwitch = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider other)
    {
        if (other.name == "Player" && puzzleSolved)
        {
            animator.SetBool("Opened", true);
            animatorSwitch.SetBool("Switch", true);
        }

    }
}
