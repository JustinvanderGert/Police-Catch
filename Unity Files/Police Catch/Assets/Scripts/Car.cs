using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Car : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip vroom;
    public AudioClip weehooh;

    public GameObject zwaailicht;
    public GameObject cameraSpot;
    public GameObject playerExit;
    public GameObject exhaust;
    public GameObject player;

    public Text enterCar;
    public bool activateWeehooh;
    public bool activateVroom;

    public float turnspeed;
    public float acceleration;


    void Start()
    {
        cameraSpot.SetActive(false);
        exhaust.SetActive(false);
        AudioSource weehooh = GetComponent<AudioSource>();
        weehooh.Stop();
    }

    void Update()
    {
        AudioSource weehooh = GetComponent<AudioSource>();

        if (!player.activeSelf && Input.GetButtonDown("E"))
        {
            StartCoroutine(GetOut());
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 7.5f & player.activeSelf)
        {
            enterCar.text = ("Press E to enter car");

            if (Input.GetButtonDown("E"))
            {
                player.SetActive(false);
                cameraSpot.SetActive(true);
                exhaust.SetActive(true);
            }
        }
        else
        {
            enterCar.text = ("");
        }

        if (Input.GetButtonDown("Q") && !player.activeSelf)
        {
            if (activateWeehooh)
            {
                weehooh.Play();
            }
            else { weehooh.Stop(); }

            zwaailicht.SetActive(activateWeehooh);
            activateWeehooh = !activateWeehooh;
        }
        if (activateVroom)
        {
            audioSource.PlayOneShot(vroom, 0.7F);
        }
    }

    void FixedUpdate()
    {
        Driving();
    }

    public void Driving()
    {
        if (!player.activeSelf)
        {
            activateVroom = true;
            if (Input.GetButton("W"))
            {
                acceleration += 0.2f;
                gameObject.transform.Translate(1, 0, 0);
            }
            if (Input.GetButton("S"))
            {
                acceleration += 0.2f;
                gameObject.transform.Translate(-1, 0, 0);
            }
            if (Input.GetButton("D"))
            {
                turnspeed += 0.2f;
                gameObject.transform.Rotate(0, +1.5f, 0);
            }
            if (Input.GetButton("A"))
            {
                turnspeed += 0.2f;
                gameObject.transform.Rotate(0, -1.5f, 0);
            }
        }
    }

    public IEnumerator GetOut()
    {
        AudioSource weehooh = GetComponent<AudioSource>();
        yield return new WaitForSeconds(0.1f);
        player.SetActive(true);
        cameraSpot.SetActive(false);
        zwaailicht.SetActive(false);
        exhaust.SetActive(false);
        player.transform.position = playerExit.transform.position;
        weehooh.Stop();
        activateVroom = false;
    }
}