using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int timeTillDeath;

    void Start ()
    {
        StartCoroutine(DestroyBullet());
    }

    void FixedUpdate ()
    {
        gameObject.transform.Translate(speed, 0, 0);
	}
    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeTillDeath);
        Destroy(gameObject);
    }
}