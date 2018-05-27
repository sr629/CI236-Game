using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compilertrigger : MonoBehaviour
{

    public static bool paused = false;
    public GameObject compilerstatus;
    public GameObject player;
    private PlayerControl playerScript;
    private DashScript dashScript;
    private PlayerGun shootScript;
    private void Start()
    {
        compilerstatus.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerControl>();
        dashScript = player.GetComponent<DashScript>();
        shootScript = player.GetComponent<PlayerGun>();
    }
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerScript = player.GetComponent<PlayerControl>();
            dashScript = player.GetComponent<DashScript>();
            shootScript = player.GetComponent<PlayerGun>();
        }
        if (Input.GetKeyDown(KeyCode.C))           // fix this to implement on collider
        {
            if (paused==true)
            {
                Resume();
                playerScript.enabled = true;
                dashScript.enabled = true;
                shootScript.enabled = true;


            }
            else
            {
                Pause();
                playerScript.enabled = false;
                dashScript.enabled = false;
                shootScript.enabled = false;
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
