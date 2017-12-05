using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjective : MonoBehaviour
{
    public GameObject stationCameraSpot;
    public GameObject station;
    public GameObject panel;
    public bool isOn;

    public Button missions;

	void Start ()
    {
        stationCameraSpot.SetActive(false);
        isOn = false;
	}
	
	void Update ()
    {
        float distance = Vector3.Distance(station.transform.position, transform.position);
        if(distance <= 2 && Input.GetButtonDown("E"))
        {
            stationCameraSpot.SetActive(true);
        }
	}

    public void TaskOnClick()
    {
        isOn = !isOn;
        panel.SetActive(isOn);
    }
}