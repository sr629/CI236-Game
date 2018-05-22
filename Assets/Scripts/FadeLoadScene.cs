using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLoadScene : MonoBehaviour {

    public static FadeLoadScene Instance { get; private set; }
    public Animator animator;
    // Use this for initialization
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	
    public IEnumerator FadeToLevel(int levelIndex)
    { 
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
    public IEnumerator FadeToLevel(string levelName)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName);
    }
}
