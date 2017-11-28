using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

    public float moveSpeed = 5;
    public float rotationSpeed = 10;
    public float verticalRotation = 0;
    public float upDownRange = 60;

    public Enemy enemy;

    void Update()
    {
        Move();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Physics.Raycast(transform.position, transform.forward * 100) && Input.GetButtonDown("Fire1"))
        {
            enemy.DealDamage(1);
        }
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
    }

    public void Move()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.Rotate(0, rotX, 0);

        verticalRotation -= rotY;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        float forwardSpeed = Input.GetAxis("Vertical");
        float sideSpeed = Input.GetAxis("Horizontal");
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;

        UnityEngine.CharacterController cc = GetComponent<UnityEngine.CharacterController>();
        cc.SimpleMove(speed * moveSpeed);
    }
}
