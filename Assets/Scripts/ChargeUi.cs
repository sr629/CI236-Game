using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeUi : MonoBehaviour {

    public Slider chargeSlider;
    public PlayerGun gun;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chargeSlider.value = gun.ammo;
    }
}
