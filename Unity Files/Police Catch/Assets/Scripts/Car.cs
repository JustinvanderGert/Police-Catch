using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject player;
    public Text enterCar;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= 7.5f)
        {
            enterCar.text = ("Press E to enter car");
        }
        else
        {
            enterCar.text = ("");
        }
	}
}