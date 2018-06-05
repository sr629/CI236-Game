using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeUi : MonoBehaviour {

    public Slider chargeSlider;
    public PlayerGun gun;

    public static ChargeUi Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!gun)
        {
            gun = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>();
        }
        chargeSlider.value = gun.ammo;
    }
}
