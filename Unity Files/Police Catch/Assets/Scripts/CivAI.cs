using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public Animator animator;
    Vector3 oldTarget;

    bool startwalking;

    void Start()
    {
        StartCoroutine(StartWalking());
    }
    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (startwalking)
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                animator.SetBool("Walking", true);
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                oldTarget = newPos;
                agent.SetDestination(newPos);
                timer = 0;
            }
            if (gameObject.transform.position == oldTarget)
            {
                animator.SetBool("Walking", false);
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public IEnumerator StartWalking()
    {
        yield return new WaitForSeconds(Random.Range(0, 55));
        startwalking = true;
    }
}