using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        }
	}
}