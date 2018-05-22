using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private Vector2 lastMove;

	public bool dashAvailable;
	public float dashSpeed;
	public float dashDistance;
    public LayerMask dashMask;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f ) 
		{
			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed * Time.deltaTime, 0f , 0f));
			myRigidbody.velocity = new Vector2(Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f ) 
		{
			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * currentMoveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2( myRigidbody.velocity.x , Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}

		if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal" ) > -0.5f)
		{
			myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y); 	
		}

		if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
		{
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f); 	
		}


		if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
			currentMoveSpeed = moveSpeed *0.66f;
		} else
			currentMoveSpeed = moveSpeed;

        if (Input.GetButtonDown("Jump") && dashAvailable)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = target -  new Vector2(transform.position.x, transform.position.y);
            DashScript dashScript = GetComponent<DashScript>();
            dashScript.Dash(dashDistance, dashSpeed, direction.normalized,dashMask);
        }

       
        anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
        
	}
    
}
