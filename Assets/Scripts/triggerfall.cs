using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private DashScript dashScript;
    private Rigidbody2D rb;
    private PlayerControl script;

    void Start()
    {
        dashScript = GetComponent<DashScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        script = GetComponent<PlayerControl>();
    }

    
    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (dashScript.isDashing == false)
        {
            if (col.gameObject.tag == "Pit" )
            {

                spriteRenderer.sortingOrder = 5;
                spriteRenderer.sortingLayerName = "Background";
                script.enabled = false;
                rb.gravityScale = 1.5f;
                
                StartCoroutine(GameMaster.Instance.KillWithDelay(gameObject, 1));
            }
        }
    }
 
}
