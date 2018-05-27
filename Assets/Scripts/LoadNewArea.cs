using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewArea : MonoBehaviour {

    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("LoadTrigger");
            StartCoroutine(FadeLoadScene.Instance.FadeToLevel(sceneName));
        }

    }
}
