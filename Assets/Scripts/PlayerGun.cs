using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {


    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed = 5.0f;
    public int startingAmmo = 5;
    public int ammo;
    public int rechargeRate = 1;
    private float timer;
    public float timeBetweenShots = 0.3333f;
    private float timestamp;
    private bool reloading;
    public bool shootAvailable;



    // Use this for initialization
    //void Start () {
    //}

    // Update is called once per frame
    //void Update () {


    //        if (Input.GetButtonDown("Fire1") && ammo > 0 && Time.time >= timestamp)
    //        {
    //            Fire();
    //            //take away from ammo
    //            ammo -= 1;

    //            timestamp = Time.time + timeBetweenShots;
    //        }

    //        if (ammo != startingAmmo && !reloading)
    //        {
    //            StartCoroutine(Recharge());
    //        }
        

    //}

    public void Shoot()
    {
        if (shootAvailable && ammo > 0 && Time.time >= timestamp)
        {
            Fire();
            //take away from ammo
            ammo -= 1;

            timestamp = Time.time + timeBetweenShots;
        }

        if (ammo != startingAmmo && !reloading)
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
        Vector2 spawn = new Vector2(bulletSpawn.position.x, bulletSpawn.position.y);


        //calculating vector for direction
        Vector2 direction = cursorPos - spawn;
        direction.Normalize();


        //rotation of sprite
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);

        //create bullet
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, spawn, rotation);
        //add velocity
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;

    }
    IEnumerator Recharge()
    {
        reloading = true;
        while (ammo < startingAmmo)
        {
            ammo++;
            yield return new WaitForSeconds(rechargeRate);
                  
        }
        reloading = false;
    }
}
