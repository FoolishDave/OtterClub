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

    /// <summary>
    /// Initializer for the agent control script
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
    /// Update the enemy target location if the player keeps moving, attack if within range
    /// </summary>
    private void FixedUpdate()
    {
        if (target != null)
        {
            agent.destination = target.transform.position;
            if (Vector3.Distance(transform.position, target.transform.position) < acceptableDistance)
            {
                attack();
            }
        }
    }

    /// <summary>
    /// Attacks the target if withing range
    /// TODO:
    /// </summary>
    private void attack ()
    {
        
        Debug.Log("I am within range Senpai");
    }
}
