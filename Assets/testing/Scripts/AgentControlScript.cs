using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Manager for the enemy (unity-chan) agents
/// </summary>
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
    }

    /// <summary>
    /// Sets the ai target location
    /// </summary>
    /// <param name="position">sets the target position</param>
    public void setTarget(Vector3 position)
    {
        destination = target.transform;
        agent.SetDestination(destination.position);
    }
}
