using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEnemies : MonoBehaviour {

    private EnemyAI[] enemyScript;

	// Use this for initialization
	void Start () {
        enemyScript = GetComponentsInChildren<EnemyAI>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (EnemyAI script in enemyScript)
            {
                script.enabled = true;
            }
        }
    }

}
