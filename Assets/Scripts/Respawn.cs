using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {


    private Transform spawnPoint;
    public int spawnDelay;
    public GameObject playerPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameMaster gameMaster=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            gameMaster.KillPlayer(gameObject);
        }
    }

}
