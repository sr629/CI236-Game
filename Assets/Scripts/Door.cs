using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool switch1;


    private Animator doorAnimator;
    private OpenDoor opedScript;

    // Use this for initialization
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        opedScript = GetComponentInChildren<OpenDoor>();

    }
    private void Update()
    {
        doorAnimator.SetBool("Opened", switch1);
    }

}
