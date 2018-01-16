using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject taser;
    public GameObject pistol;
    public GameObject bullet;

    GameObject activeWeapon;


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { activeWeapon = taser; }
        if (Input.GetButtonDown("Fire2")) { activeWeapon = pistol; }

		if(Input.GetButtonDown("Fire1") && activeWeapon == taser)
        {
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        }

        if(pistol == activeWeapon) { Instantiate(pistol, gameObject.transform.position, gameObject.transform.rotation); }
        else { DestroyImmediate(pistol); }

        if (taser == activeWeapon) { Instantiate(taser, gameObject.transform.position, gameObject.transform.rotation); }
        else { DestroyImmediate(taser); }
    }
}