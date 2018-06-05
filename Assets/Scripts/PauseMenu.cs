using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // Use this for initialization
    private bool paused = false;
    private GameObject panel;
    void Start()
    {
        panel = transform.GetChild(0).gameObject;
        panel.SetActive(false); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("test");
            if (paused)
                ClosePauseMenu();
            else if (!paused)
                OpenPauseMenu();
            paused = !paused;
        }
    }

    public void OpenPauseMenu()
    {
        Time.timeScale = 0;
        PlayerControl.Instance.enabled = false;
        panel.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        PlayerControl.Instance.enabled = true;

    }
}
