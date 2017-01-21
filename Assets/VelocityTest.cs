using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityTest : MonoBehaviour {

    SteamVR_TrackedController tracked;
    public GameObject speedText;

	void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Weapon"))
        {
            tracked = col.GetComponentInParent<SteamVR_TrackedController>();
            Vector3 velocity = SteamVR_Controller.Input((int)tracked.controllerIndex).velocity;
            speedText.GetComponent<TextMesh>().text = velocity.sqrMagnitude.ToString();
        }
    }
}
