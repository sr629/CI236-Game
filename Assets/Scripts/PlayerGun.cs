using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {


    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed = 5.0f;
    public int startingAmmo = 3;
    public int ammo = 3;
    public float rechargeRate = 1;
    public float timeTillRecharge = 3;
    private float timeFromLastFire;
    public float timeBetweenShots;
    private float timestamp;
    private bool reloading;



    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        

        if (Input.GetButtonDown("Fire1") && ammo > 0 && Time.time >= timestamp)
        {
            timeFromLastFire = 0;

            Fire();
            //take away from ammo
            ammo -= 1;

            timestamp = Time.time + timeBetweenShots;
        }

        timeFromLastFire += 1.0F * Time.deltaTime;

        if (ammo != startingAmmo && !reloading && timeFromLastFire >= timeTillRecharge)
        {
            StartCoroutine(Recharge());
        }

    }

    private void reload()
    {
        ammo += 1;
    }

    void Fire()
    {
        Debug.Log("bullet fire");
        //finding cursor position
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //finding character position
        Vector2 characterPos = new Vector2(transform.position.x, transform.position.y);


        //calculating vector for direction
        Vector2 direction = cursorPos - characterPos;
        direction.Normalize();


        //rotation of sprite
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);

        //create bullet
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, characterPos, rotation);
        //add velocity
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;

    }
    IEnumerator Recharge()
    {
        reloading = true;
        while (ammo < startingAmmo && timeFromLastFire >= timeTillRecharge)
        {
            ammo++;
            yield return new WaitForSeconds(rechargeRate);
                  
        }
        reloading = false;
    }
}
