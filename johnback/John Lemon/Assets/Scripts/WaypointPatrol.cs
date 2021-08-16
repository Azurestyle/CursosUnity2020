using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public Transform[] waypoints;

    private int currentWaypointIndex =0;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        // si la distancia para llegar a un punto es menor que la distancia de parada
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            // si en waypoints hay 5 elementos, el resto es lo que sobra y volvería al 0
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
