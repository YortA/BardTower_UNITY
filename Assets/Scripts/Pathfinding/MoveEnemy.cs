using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Currently the destination LAGS when calculating the movement. We need to cache destination or create AI in order to respond to where
// our agents are going.


[RequireComponent(typeof(NavMeshAgent))]
public class MoveEnemy : MonoBehaviour
{
    public Transform target;
    private Vector3 destination;
    private NavMeshAgent agent;
    //private LineRenderer line;



    void Start()
    {
        //line = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        //destination = agent.destination;
        target.position = TargetDestinationRandom.MoveBehave.TargetPoint;
        destination = target.position;
  
    }

    void Update()
    {
        if (Vector3.Distance(destination, target.position) > 1f)
        {
            Debug.Log("Agent Attempting to move.");
        
            //destination = target.position;
            agent.destination = destination;
        }
    }
}
