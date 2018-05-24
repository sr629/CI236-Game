using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {


        private bool OnOff;
        private Animator animator;
        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider other)
        {
            if (other.name == "Player")
            {
            animator.SetBool("Opened", true);
            OnOff = true;
            }

        }
    }
