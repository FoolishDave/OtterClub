using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    WandController parentScript;

    void Start()
    {
        parentScript = GetComponentInParent<WandController>();
    }

	void OnTriggerEnter(Collider col)
    {
        parentScript.OnTriggerEnter(col);
    }

    void OnTriggerExit(Collider col)
    {
        parentScript.OnTriggerExit(col);
    }
}
