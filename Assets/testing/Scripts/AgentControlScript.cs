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
    private LocomotionSimpleAgent locoAgent;

    private GameObject target;

    public static float distance = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        locoAgent = this.gameObject.GetComponent<LocomotionSimpleAgent>();
    }

    /// <summary>
    /// Sets the ai target location
    /// </summary>
    /// <param name="position">sets the target position</param>
    public void setMovementTarget(Vector3 position)
    {
        agent.destination = position;
    }

    /// <summary>
    /// Sets the attacking target, this will cause the agent to move towards and attack the target
    /// </summary>
    /// <param name="Attacktarget">The target to attack</param>
    public void setAttackTarget(GameObject Attacktarget)
    {
        target = Attacktarget;
    }

    /// <summary>
    /// Update is used to manage the agent's attacking state.
    /// When target is null, the enemy will not attack or move towards the player
    /// When the target is set, the enemy will move towards the player
    /// When the target is set and the enemy is in range, the enemy will attack the player
    /// </summary>
    private void Update()
    {
        if (target != null)
        {
            setMovementTarget(target.transform.position);
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) < AgentControlScript.distance)
            {
                locoAgent.attacking = true;
                Debug.Log("I am attacking Senpai! Are you proud?");
            }
        }
        else
        {
            locoAgent.attacking = false;
        }
    }
}
