﻿using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{

    public float movementSpeed = 10;
    public float mouseSensitivity = 5.0f;
    public float upDownRange = 60.0f;
    float verticalRotation = 0;
    
    void Start()
    {
        Screen.lockCursor = true;
    }
    
    void Update()
    {
        //Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);



        //movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        speed = transform.rotation * speed;

        UnityEngine.CharacterController cc = GetComponent<UnityEngine.CharacterController>();

        cc.SimpleMove(speed);
    }
}