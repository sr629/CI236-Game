using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideFollow : MonoBehaviour {

	// Use this for initialization
	private Animator animator;
	private GameObject player;
	public float maxDistance;
	public float moveSpeed;
    private static GameObject Instance;
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
        {
            //if not, set instance to this
            Instance = this.gameObject;
        }
        //If instance already exists and it's not this:
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}
		if (Vector2.Distance (transform.position, player.transform.position) > maxDistance) {
			transform.position = Vector2.Lerp (transform.position, player.transform.position, moveSpeed*Time.deltaTime);

		}
		Vector2 direction = (Vector2)transform.position - (Vector2)player.transform.position;

		direction = direction.normalized;
		animator.SetFloat ("MoveX", direction.x);
		animator.SetFloat ("MoveY", direction.y);
	}
}
