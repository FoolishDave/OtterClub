using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentControlScript : MonoBehaviour {

    /// <summary>
    /// Destination of the agent
    /// </summary>
    public Transform destination;

    /// <summary>
    /// Agent nav mesh
    /// </summary>
    private NavMeshAgent agent;

    /// <summary>
    /// Agent Target
    /// </summary>
    public GameObject target;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        destination = target.transform;
        agent.SetDestination(destination.position);
    }
}
