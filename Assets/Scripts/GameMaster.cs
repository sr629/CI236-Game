using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    // Use this for initialization
    public bool dash;
    public bool door; 
    public bool gun;
    public bool door2;
    public bool saw;
    public bool sawMove;
    private GameObject[] spawnPoints;
    private GameObject closestSpawn;
    public int spawnDelay=1;
    public GameObject playerPrefab;


    void Start()
    {
        ChargeUi.Instance.gameObject.SetActive(false);
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
    public void UpdateProgress(int index)
    {
        switch (index)
        {
            case 1:
                dash = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<DashScript>().enabled = dash;
                break;
            case 2:
                door = true;
                GameObject.FindGameObjectWithTag("Door1").GetComponent<Animator>().SetBool("Opened", true);
                break;
            case 3:
                saw = true;
                GameObject[] saws = GameObject.FindGameObjectsWithTag("SawStatic");
                foreach (GameObject item in saws)
                {
                    item.GetComponent<Animator>().SetBool("Hide", saw);
                }
                break;
            case 4:
                sawMove = true;
                GameObject.FindGameObjectWithTag("MoveSaw").GetComponent<Animator>().speed = 0.3f;
                break;
            case 5:
                door2 = true;
                GameObject.FindGameObjectWithTag("Door2").GetComponentInChildren<OpenDoor>().puzzleSolved = door2;
                break;

            case 6:
                gun = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>().shootAvailable = gun;
                ChargeUi.Instance.gameObject.SetActive(gun);
                break;
            default:
                break;
        }
    }

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, closestSpawn.transform.position, closestSpawn.transform.rotation);
        GameObject.FindGameObjectWithTag("Player").GetComponent<DashScript>().enabled = dash;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>().shootAvailable = gun;
    }

    public void KillPlayer(GameObject player)
    {
        Debug.Log("KillPlayer");
        setClosestSpawnPoint(player.transform.position);
        Destroy(player.gameObject);
        FadeLoadScene.Instance.GetComponent<Animator>().SetTrigger("Fade");
        StartCoroutine(GameMaster.Instance.RespawnPlayer());
    }

    public IEnumerator KillWithDelay( GameObject player, float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("KillwithDelay");
        KillPlayer(player);
    }

    private void setClosestSpawnPoint(Vector2 playerPos)
    {   
        if (spawnPoints == null)
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
    public void Quit()
    {
        Application.Quit();
    }
}
