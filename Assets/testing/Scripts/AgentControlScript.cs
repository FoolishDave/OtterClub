using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Manager for the enemy (unity-chan) agents
/// </summary>
public class AgentControlScript : MonoBehaviour {

    /// <summary>
    /// Agent nav mesh
    /// </summary>
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Sets the ai target location
    /// </summary>
    /// <param name="position">sets the target position</param>
    public void setTarget(Vector3 position)
    {
        agent.destination = (position);
    }
}
