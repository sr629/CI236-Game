using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewArea : MonoBehaviour {

    public string sceneName;
    private FadeLoadScene fadeLoadScene;
	// Use this for initialization
	void Start () {
        fadeLoadScene = GameObject.Find("FadeEffect").GetComponent<FadeLoadScene>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("LoadTrigger");
            StartCoroutine(fadeLoadScene.FadeToLevel(sceneName));
        }

    }
}
