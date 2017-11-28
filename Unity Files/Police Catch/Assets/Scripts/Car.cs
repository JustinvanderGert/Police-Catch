using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public GameObject cameraSpot;
    public Text enterCar;

	void Start ()
    {
        GameObject player = GameObject.Find("Player");
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

        if(Input.GetButtonDown("E"))
        {
            PlayerMOV playerMov = player.GetComponent<PlayerMOV>();
            playerMov.allowed = false;

            mainCamera.transform.position = cameraSpot.transform.position;
        }
    }
}