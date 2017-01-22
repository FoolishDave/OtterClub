using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPresser : MonoBehaviour {

    SteamVR_LaserPointer laserPointer;
    SteamVR_TrackedController trackedController;
    GameObject hovered;

	// Use this for initialization
	void Start () {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        trackedController = GetComponent<SteamVR_TrackedController>();
        laserPointer.PointerIn += new PointerEventHandler(OnHoverOver);
        laserPointer.PointerOut += new PointerEventHandler(OnLeaveHover);
        trackedController.TriggerClicked += new ClickedEventHandler(TriggerPull);
	}
	
    void OnHoverOver(object sender, PointerEventArgs e)
    {
        if (e.target.tag.Equals("VRButton"))
        {
            hovered = e.target.gameObject;
            if (e.target.GetComponent<Renderer>() != null)
                e.target.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnLeaveHover(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject == hovered)
            hovered = null;
        if (e.target.GetComponent<Renderer>() != null)
            e.target.GetComponent<Renderer>().material.color = Color.white;
    }

    void TriggerPull(object sender, ClickedEventArgs e)
    {
        hovered.SendMessage("OnPress");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
