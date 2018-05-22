using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rb;
    private Vector2 dashTarget;
    private float dashSpeed;
    private bool isDashing;
	void Start () {
        rb = GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        if (this.gameObject==null)
        {
            return;
        }

        if (isDashing)
        {
            rb.velocity = Vector2.zero;
            float distSqr = (dashTarget - new Vector2(transform.position.x, transform.position.y)).sqrMagnitude;
            if (distSqr < 0.1f)
            {
                isDashing = false;
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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, dashDistance, layerMask);

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
}
