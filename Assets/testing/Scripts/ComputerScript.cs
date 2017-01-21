using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {
    

	void Start () {
		
	}


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 newPosition = hit.point;

            }
        }
    }
}
