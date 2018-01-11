using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Zwaailicht : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update ()
    {
        gameObject.transform.Rotate(0, 3.5f, 0);
    }
}