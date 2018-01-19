using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject pistol;
    public GameObject taser;
    GameObject activeWeapon;
    bool spawned;


    private void Start()
    {
        pistol.SetActive(false);
        pistol.SetActive(false);

        activeWeapon = null;
    }

    void Update()
    {
        pistol.transform.position = gameObject.transform.position;
        taser.transform.position = gameObject.transform.position;

        if (Input.GetButtonDown("One") && activeWeapon != taser)
        {
            activeWeapon = taser;
            taser.SetActive(true);
            pistol.SetActive(false);
        }

        if (Input.GetButtonDown("Two") && activeWeapon != pistol)
        {
            activeWeapon = pistol;
            pistol.SetActive(true);
            taser.SetActive(false);
        }

		if(Input.GetButtonDown("Fire1") && activeWeapon != null)
        {
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}