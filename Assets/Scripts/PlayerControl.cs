using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;
    public static PlayerControl Instance;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private Vector2 lastMove;

	public float dashSpeed;
	public float dashDistance;
    public LayerMask dashMask;
    private float lastDash;

    private DashScript dashScript;
    private PlayerGun gunScript;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
        dashScript = GetComponent<DashScript>();
        gunScript = GetComponent<PlayerGun>();
	}

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

        if (Input.GetButtonDown("Jump") && GameMaster.Instance.dash && Time.time - lastDash >= 0.5f)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = target -  new Vector2(transform.position.x, transform.position.y);
            dashScript.Dash(dashDistance, dashSpeed, direction.normalized,dashMask);
            lastDash = Time.time;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            gunScript.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

       
        anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StaticSaw" || collision.tag == "MoveSaw")
        {
            GameMaster.Instance.KillPlayer(gameObject);
        }
    }
}
