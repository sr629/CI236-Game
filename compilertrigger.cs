using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compilertrigger : MonoBehaviour
{

    public static bool paused = false;
    public GameObject compilerstatus;
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))           // fix this to implement on collider
        {
            if (paused == true)
            {
                Resume();
                player.GetComponent<DashScript>().enabled = true;
                player.GetComponent<PlayerGun>().enabled = true;


            }
            else
            {
                Pause();
                player.GetComponent<DashScript>().enabled = false;
                player.GetComponent<PlayerGun>().enabled = false;

            }
        }
    }
    void Resume()
    {
        compilerstatus.SetActive(false);
        Time.timeScale = 1;
        paused = false;

    }
    void Pause()
    {
        compilerstatus.SetActive(true);
        Time.timeScale = 0;
        paused = true;

    }
}
