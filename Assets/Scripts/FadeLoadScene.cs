using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLoadScene : MonoBehaviour
{

    public static FadeLoadScene Instance;
    private Animator animator;
    private PlayerControl playerScript;
    private Rigidbody2D playerRB;
    private Canvas canvas;
    // Use this for initialization
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
        {
            //if not, set instance to this
            Instance = this;
        }
        //If instance already exists and it's not this:
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = true;
        

        animator = GetComponent<Animator>();
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            playerRB = playerScript.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    public void StartTransition(int index)
    {
        StartCoroutine(FadeToLevel(index));
    }
    public void StartTransition(string name)
    {
        StartCoroutine(FadeToLevel(name));
    }

    public IEnumerator FadeToLevel(int levelIndex)
    {
        
        if (!playerScript && GameObject.FindGameObjectWithTag("Player"))
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            playerRB = playerScript.gameObject.GetComponent<Rigidbody2D>();
        }
        if (playerScript)
        {
            playerScript.enabled = false;
            playerRB.velocity = Vector2.zero;
        }
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
        animator.SetTrigger("");
        if (playerScript)
        {
            playerScript.enabled = true;
        }
        Debug.Log("It works");
    }
    public IEnumerator FadeToLevel(string levelName)
    {
        Debug.Log("It works");
        if (!playerScript && GameObject.FindGameObjectWithTag("Player"))
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            playerRB = playerScript.gameObject.GetComponent<Rigidbody2D>();
        }
        if (playerScript)
        {
            playerScript.enabled = false;
            playerRB.velocity = Vector2.zero;
        }
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName);
        if (playerScript)
        {
            playerScript.enabled = true;
        }
        
    }
}
