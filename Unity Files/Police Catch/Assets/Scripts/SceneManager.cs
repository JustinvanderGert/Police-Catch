using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject uiCanvas;
    public GameObject station;
    public GameObject player;

	void Start ()
    {
        pauseScreen.SetActive(false);
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            uiCanvas.SetActive(false);
            player.SetActive(false);
            station.GetComponent<StationMenu>().wantedMode = CursorLockMode.None;
        }
	}

    public void ResumeClicked()
    {
        pauseScreen.SetActive(false);
        uiCanvas.SetActive(true);
        player.SetActive(true);
        station.GetComponent<StationMenu>().wantedMode = CursorLockMode.Locked;
    }

    public void ExitClicked()
    {
        //Application.LoadLevel("Menu");
    }
}