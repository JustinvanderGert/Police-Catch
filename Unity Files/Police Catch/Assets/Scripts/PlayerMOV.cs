using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOV : MonoBehaviour
{
    public Camera mainCamera;
    public float speed;
    public float lookSpeed;
    
    public float rotationSpeed = 10;
    public float verticalRotation = 0;
    public float upDownRange = 60;

    public bool allowed;

	
	void FixedUpdate ()
    {
        if (allowed == true)
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.Rotate(0, rotX, 0);

            verticalRotation -= rotY;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

            float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(moveHorizontal, 0.0f, moveVertical);
        }
	}
}