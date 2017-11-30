using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject cameraSpot;
    public GameObject player;
    public Text enterCar;
    public GameObject zwaailicht;

    public bool activate;

    void Start()
    {
        cameraSpot.SetActive(false);
    }

    void Update()
    {
        if (!player.activeSelf && Input.GetButtonDown("E"))
        {
            StartCoroutine(GetOut());
            print("test");
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 7.5f & player.activeSelf)
        {
            enterCar.text = ("Press E to enter car");

            if (Input.GetButtonDown("E"))
            {
                player.SetActive(false);
                cameraSpot.SetActive(true);
            }
        }
        else
        {
            enterCar.text = ("");
        }

        if (Input.GetButtonDown("Q") && !player.activeSelf)
            {
                zwaailicht.SetActive(activate);
                activate =! activate;
            }
        if (Input.GetButtonDown("Jump"))
        {
            player.SetActive(true);
            cameraSpot.SetActive(false);
            zwaailicht.SetActive(false);
        }


        if (!player.activeSelf)
        {
            if (Input.GetButton("W"))
            {
                gameObject.transform.Translate(1, 0, 0);
            }
            if (Input.GetButton("S"))
            {
                gameObject.transform.Translate(-1, 0, 0);
            }
            if (Input.GetButton("A"))
            {
                gameObject.transform.Rotate(0, +1.5f, 0);
            }
            if (Input.GetButton("D"))
            {
                gameObject.transform.Rotate(0, -1.5f, 0);
            }
        }
    }

    public IEnumerator GetOut()
    {
        yield return new WaitForSeconds(0.1f);
        player.SetActive(true);
        cameraSpot.SetActive(false);
        zwaailicht.SetActive(false);
    }
}