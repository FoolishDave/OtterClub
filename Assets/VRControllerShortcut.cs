using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControllerShortcut : MonoBehaviour {

    public static SteamVR_TrackedController leftController;
    public static SteamVR_TrackedController rightController;
    public SteamVR_TrackedController left;
    public SteamVR_TrackedController right;

	// Use this for initialization
	void Start () {
        leftController = left;
        rightController = right;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
