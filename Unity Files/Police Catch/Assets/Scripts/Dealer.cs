﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dealer : MonoBehaviour
{
    [SerializeField] Transform Player;
    NavMeshAgent agent;

    float multiplier = 1;
    float range = 30;
    bool seen;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 runTo = transform.position + ((transform.position - Player.position) * multiplier);
        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance < range) agent.SetDestination(runTo);
    }
}