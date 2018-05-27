using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rb;
    private Vector2 dashTarget;
    private float dashSpeed;
    public bool isDashing;
    private Animator anim;
    private Collider2D pitCollider;

    //Dash
    List<GameObject> trailParts = new List<GameObject>();
    public float rate = 0.2f;
    public float ghostLife = 0.5f;
    public float opacity = 0.5f;

    //direction
    private Vector2 endDirection;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pitCollider = GameObject.FindGameObjectWithTag("Pit").GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {
        //anim.SetBool("Dashing", isDashing);
	}
    void FixedUpdate()
    {
    	if (this.gameObject == null)
    	{
    		return;
    	}
        if (isDashing)
        {
            InvokeRepeating("SpawnTrailPart", 0, rate);

            rb.velocity = Vector2.zero;
            float distSqr = (dashTarget - new Vector2(transform.position.x, transform.position.y)).sqrMagnitude;
            if (distSqr < 0.1f)
            {
                anim.SetFloat("DashDirectionX", endDirection.x);
                anim.SetFloat("DashDirectionY", endDirection.y);

                isDashing = false;
                if (pitCollider != null) pitCollider.isTrigger = false;
                dashTarget = Vector2.zero;
            }
            else
            {
                rb.MovePosition(Vector3.Lerp(transform.position,
                    dashTarget, dashSpeed * Time.deltaTime));
            }
        }

    }

    public void Dash(float dashDistance, float speed, Vector2 direction, LayerMask layerMask)
    {

        isDashing = true;
       // anim.SetFloat("DashDirectionX", direction.x);
       // anim.SetFloat("DashDirectionY", direction.y);
       // anim.SetFloat("LastMove", direction.x);
       // anim.SetFloat("LastMove", direction.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, dashDistance, layerMask);
        if (pitCollider != null)
        {
            pitCollider.isTrigger = true;
        }

        
        if (hit)
        {
            dashTarget = transform.position + (Vector3)((direction * dashDistance) * hit.fraction);
        }
        else
        {
            dashTarget = transform.position + (Vector3)(direction * dashDistance);
        }

        dashSpeed = speed;
        rb.velocity = Vector2.zero;
    }
    void SpawnTrailPart()
    {
        if (isDashing) { 
        GameObject trailPart = new GameObject();
        SpriteRenderer trailPartRenderer = trailPart.AddComponent<SpriteRenderer>();
        trailPartRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
        trailPart.transform.position = transform.position;
        trailPart.transform.localScale = transform.localScale;

            if (trailPartRenderer)
            {
                trailPartRenderer.sortingOrder = 0;
                trailPartRenderer.sortingLayerName = "Player";
            }

            trailParts.Add(trailPart);

        StartCoroutine(FadeTrailPart(trailPartRenderer));
        Destroy(trailPart, ghostLife);
        }
    }

    IEnumerator FadeTrailPart(SpriteRenderer trailPartRenderer)
    {
        Color color = trailPartRenderer.color;
        color.a -= opacity;
        trailPartRenderer.color = color;

        yield return new WaitForEndOfFrame();
    }
}
