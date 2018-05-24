using System.Collections;
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

        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
	}
    public static GameMaster Instance;
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

    private GameObject[] spawnPoints;
    private GameObject closestSpawn;
    public int spawnDelay;
    public GameObject playerPrefab;

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, closestSpawn.transform.position, closestSpawn.transform.rotation);
    }

    public void KillPlayer(GameObject player)
    {
        Debug.Log("KillPlayer");
        setClosestSpawnPoint(player.transform.position);
        
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public IEnumerator KillWithDelay( GameObject player, float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("KillwithDelay");
        KillPlayer(player);
    }

    private void setClosestSpawnPoint(Vector2 playerPos)
    {   
        if (spawnPoints[0]==null)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        }
        closestSpawn = spawnPoints[0];
        float shortestDistance = Vector2.Distance(playerPos, closestSpawn.transform.position);
        foreach (GameObject point in spawnPoints)
        {
            float curDist = Vector2.Distance(playerPos, point.transform.position);
            if (shortestDistance > curDist)
            {
                shortestDistance = curDist;
                closestSpawn = point;
            }

        }
    }
}
