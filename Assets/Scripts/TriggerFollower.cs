using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFollower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Guide").GetComponent<GuideFollow>().enabled = true;


        }

    }
}
