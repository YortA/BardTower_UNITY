using UnityEngine;
using UnityEngine.AI;

// just test click to move -- not actually being used

public class TestPlayerControl : MonoBehaviour
{

    public Camera Camera;
    public NavMeshAgent Agent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray Ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(Ray, out Hit))
            {
                Agent.SetDestination(Hit.point);
            }
        }
    }
}
