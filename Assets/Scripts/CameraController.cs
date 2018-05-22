using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPosition;
	public float moveSpeed;
    private bool cameraExists;

    private float nextTimeToSearch = 0;
	// Use this for initialization
	void Start () {

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        if (followTarget==null)
        {
            FindPlayer();
            return;
        }

		targetPosition = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPosition, moveSpeed * Time.deltaTime);
		
	}

    private void FindPlayer()
    {
        if (nextTimeToSearch<=Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                followTarget = searchResult;
            nextTimeToSearch = Time.time + 2;
        }
    }
}
