using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerfall : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public bool isdashing;

    void Setup()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        DashScript dashScript = gameObject.GetComponent<DashScript>();
        
        if (dashScript.isDashing == false)
        {
            if (col.gameObject.tag == "Pit")
            {

                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                gameObject.GetComponent<PlayerControl>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                //respawn
                GameMaster gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
                gameMaster.KillWithDelay(this.gameObject, 0.5f);
            }
        }
    }
}
