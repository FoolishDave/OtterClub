using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {

    public SpawnScript spawner;
    public Camera camera;
    public static bool menuActive;

	void Start () {
		
	}


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ComputerScript.menuActive)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Spawnable")
            {
                Vector3 newPosition = hit.point;
                Debug.Log("The position is: " + newPosition);
                spawner.spawnEnemy(newPosition);
            }
        }
    }
}
