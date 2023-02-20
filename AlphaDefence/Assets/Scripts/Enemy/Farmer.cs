using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Farmer : Enemy
{
    private NavMeshAgent agent;

    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        currentHealth = health;
    }
    void Update()
    {
        agent.SetDestination(target.transform.position);            
    }

}
