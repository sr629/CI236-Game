using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private Vector2 lastMove;

	public bool dashAvailable;
	public float dashSpeed;
	private bool isDashing;
	private float dashTime;
	public float dashDistance;
	private Vector2 direction;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		dashTime = dashDistance;
		isDashing = false;
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

		if ( Input.GetButtonDown("Jump"))
		{
			
			Vector2 character = new Vector2 (transform.position.x, transform.position.y);
			character = Camera.main.ScreenToViewportPoint (character);
			Vector2 target = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			direction = target;
			direction.x *= 2;
			direction.x -= 1;
			direction.y *= 2;
			direction.y -= 1;
			Debug.Log ("Character: "+character);
			Debug.Log ("Mouse: "+target);
			Debug.Log ("Direction: "+direction);
			isDashing = true;
			//myRigidbody.velocity = direction * dashSpeed;
			//myRigidbody.AddForce (direction*dashSpeed);
		}
		if (isDashing) {
			Vector2 character = new Vector2 (transform.position.x, transform.position.y);
			character = Camera.main.ScreenToViewportPoint (character);
			myRigidbody.MovePosition(direction);
			dashTime -= dashDistance;
		}

		if (dashTime <= 0) 
		{
			myRigidbody.velocity = Vector2.zero;
			isDashing = false;
			dashTime = dashDistance;
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}

}
