using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            if (rb.tag == "Head") continue;
            rb.isKinematic = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
