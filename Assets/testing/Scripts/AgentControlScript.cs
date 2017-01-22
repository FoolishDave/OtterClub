using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Manager for the enemy (unity-chan) agents
/// </summary>
public class AgentControlScript : MonoBehaviour {

    /// <summary>
    /// The distance before the enemy will start attacking
    /// </summary>
    public float acceptableDistance = 2.0f;

    /// <summary>
    /// Agent nav mesh
    /// </summary>
    private NavMeshAgent agent;
    private LocomotionSimpleAgent locoAgent;

    public static float distance = 2f;

    /// <summary>
    /// The target of the agent, null if not attacking, assigned if attacking
    /// </summary>
    private GameObject _target;

    /// <summary>
    /// Getter and setter for the gameobject target
    /// </summary>
    public GameObject target
    {
        get { return _target; }
        set { _target = value; }
    }

    // <summary>
    // Hack to get around navmesh problems
    // </summary>
    private bool flicked;

    /// <summary>
    /// Initializer for the agent control script
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        locoAgent = this.gameObject.GetComponent<LocomotionSimpleAgent>();
    }

    /// <summary>
    /// Sets the target for movement
    /// </summary>
    /// <param name="position">the position to move to</param>
    public void SetMovementTarget(Vector3 position)
    {
        agent.destination = position;
    }

    /// <summary>
    /// Attacks the target if withing range
    /// TODO:
    /// </summary>
    /// <param name="position">sets the target position</param>
    public void setMovementTarget(Vector3 position)
    {
        if (!agent.isOnNavMesh)
        {
            Debug.Log("Flicking waifu");
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
        Vector3 oldDest = agent.destination;
        agent.SetDestination(position);        
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
        if (flicked)
        {
            flicked = false;
            gameObject.SetActive(true);
        }

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
