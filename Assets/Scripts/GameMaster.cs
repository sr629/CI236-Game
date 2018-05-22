﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    // Use this for initialization
    private GameMaster gm;
	void Start () {
        if (gm==null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
	}

    public GameObject spawnPoint;
    public int spawnDelay;
    public GameObject playerPrefab;

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void KillPlayer(GameObject player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
