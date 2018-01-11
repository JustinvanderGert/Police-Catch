using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;


	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        }
	}
}