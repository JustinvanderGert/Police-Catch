using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioClip piew;
    AudioSource audioSource;
    public GameObject bullet;
    public GameObject pistol;
    public GameObject taser;
    GameObject activeWeapon;
    bool spawned;
    bool shot;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pistol.SetActive(false);
        pistol.SetActive(false);

        shot = false;
        activeWeapon = null;
    }
    private void OnEnable()
    {
        shot = false;
    }

    void Update()
    {
        pistol.transform.position = gameObject.transform.position;
        pistol.transform.rotation = gameObject.transform.rotation;

        taser.transform.position = gameObject.transform.position;
        taser.transform.rotation = gameObject.transform.rotation;

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

        if (Input.GetButtonDown("Fire1") && activeWeapon != null && shot == false)
        {
            Debug.Log("Schiet");
            shot = true;
            audioSource.PlayOneShot(piew, 0.7F);
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
            StartCoroutine(Shoot());
        }
    }
    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(5);
        shot = false;
    }
}