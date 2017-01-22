using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {

    public SpawnScript spawner;
    public Camera camera;
    public static bool menuActive;

    /// <summary>
    /// The selected enemy to control
    /// </summary>
    public static List<AgentControlScript> selectedUnit;

	void Start () {
        selectedUnit = new List<AgentControlScript>();
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
            if (hit && rayHit.collider.gameObject.tag == "Spawnable" && rayHit.collider.gameObject.tag != "Unity~Chan<3")
            {
                selectedUnit.Clear();
                Vector3 newPosition = rayHit.point;
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

            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out rayHit, 100))
            {
                Vector3 newPosition = rayHit.point;
                selectedUnit.ForEach(enemy => enemy.setTarget(newPosition));
            }
        }
    }
}
