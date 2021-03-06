﻿using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {

    public SpawnScript spawner;
    public Camera camera;
    public static bool menuActive;
    private GameObject player;
    public bool spawningEnabled;

    /// <summary>
    /// The attacking distance
    /// </summary>
    [SerializeField]
    public float attackDistance = 2f;

    /// <summary>
    /// The selected enemy to control
    /// </summary>
    public static List<AgentControlScript> selectedUnit;

	void Start () {
        selectedUnit = new List<AgentControlScript>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
        AgentControlScript.distance = attackDistance;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ComputerScript.menuActive)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            bool hit = false;
            if (Physics.Raycast(ray, out rayHit))
            {
                hit = true;
            }

            // Check if a unity chan should be spawned
            if (hit && rayHit.collider.gameObject.tag == "Spawnable" && rayHit.collider.gameObject.tag != "Unity~Chan<3" && spawningEnabled)
            {
                selectedUnit.Clear();
                Vector3 newPosition = rayHit.point - new Vector3(0, 0.2f, 0);
                spawner.spawnEnemy(newPosition);
            }
            else if (hit && rayHit.collider.gameObject.tag == "Unity~Chan<3" && !ComputerScript.menuActive)
            {
                AgentControlScript acs = rayHit.collider.gameObject.GetComponent<AgentControlScript>();
                if (!selectedUnit.Contains(acs))
                {
                    selectedUnit.Add(acs);
                }
            }
            else
            {
                selectedUnit.Clear();
            }
        }
        else if (Input.GetMouseButtonDown(1) && !ComputerScript.menuActive)
        {
            RaycastHit rayHit;
            bool hit = false;
            // Check if there is a hit
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out rayHit, 100))
            {
                Debug.Log("The tag is: " + rayHit.collider.tag + " " + rayHit.collider.gameObject.transform.name);
                hit = true;
            }

            if (hit && rayHit.collider.gameObject.tag == "Player")
            {
                selectedUnit.ForEach(enemy => {
                    enemy.setAttackTarget(player);
                    enemy.setMovementTarget(player.transform.position);
                    });
            } else if (hit) {
                Vector3 newPosition = rayHit.point;
                selectedUnit.ForEach(enemy => {
                    enemy.setMovementTarget(newPosition);
                    enemy.setAttackTarget(null);
                    });
            }
            else
            {
                selectedUnit.ForEach(enemy => enemy.setAttackTarget(null));
            }
        }
    }
}
