using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointScript : MonoBehaviour {

    private GameObject player;
    private GameObject cameraMain;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
        
        player.transform.position = (Vector2)transform.position;
        cameraMain.transform.position = new Vector3(transform.position.x, transform.position.y, cameraMain.transform.position.z);
	}
    
	
}
