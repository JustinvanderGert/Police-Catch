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
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Dealer"))
        {
            other.gameObject.GetComponent<Dealer>().Tazed();
            Destroy(gameObject);
        }
    }
    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeTillDeath);
        Destroy(gameObject);
    }
}