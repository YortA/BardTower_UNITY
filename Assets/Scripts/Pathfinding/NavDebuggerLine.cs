using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavDebuggerLine : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent debugAgent;

    private LineRenderer lineRenderer;


    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        if (debugAgent.hasPath)
        {
            lineRenderer.positionCount = debugAgent.path.corners.Length;
            lineRenderer.SetPositions(debugAgent.path.corners);
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

}
