using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    public GameObject collided;
    public GameObject holding;
    public Transform oldParent;
    SteamVR_TrackedController trackedController;

    public GameObject leftController;
    public GameObject rightController;

    void Start() {
        trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null)
            trackedController = gameObject.AddComponent<SteamVR_TrackedController>();

        trackedController.TriggerClicked += new ClickedEventHandler(TriggerPulled);
        trackedController.TriggerUnclicked += new ClickedEventHandler(TriggerUnpulled);

        Debug.Log("Wand script A-OK");
    }

    public void OnTriggerEnter(Collider col)
    {
        var collidedTemp = col.gameObject;
        if (col.tag.Equals("Draggable") || col.tag.Equals("Grabbed"))
        {
            Debug.Log("Wand entered trigger with draggable.");
            collided = collidedTemp;
        }
        Debug.Log("Wand entered trigger.");
        SteamVR_Controller.Input((int)trackedController.controllerIndex).TriggerHapticPulse();
    }

    public void OnTriggerExit(Collider col)
    {
        if (collided != null && collided.transform.parent == transform)
        {
            collided.transform.SetParent(oldParent);
            collided.GetComponent<Rigidbody>().isKinematic = false;
        }
        collided = null;
    }

	void TriggerPulled(object sender, ClickedEventArgs e)
    {
        if (collided == null) return;
        if (collided.tag.Equals("Grabbed"))
        {
            Debug.Log("Attempted handoff");
            WandController wand;
            if (transform == leftController.transform)
            {
                wand = rightController.GetComponent<WandController>();
                oldParent = wand.oldParent;
                wand.holding = null;
            }
            else
            {
                wand = leftController.GetComponent<WandController>();
                oldParent = wand.oldParent;
                wand.holding = null;
            }
        }
        else
        {
            oldParent = collided.transform.parent;
        }
        collided.transform.SetParent(gameObject.transform);
        collided.tag = "Grabbed";
        holding = collided.gameObject;
        Rigidbody colRigid = collided.GetComponent<Rigidbody>();
        colRigid.isKinematic = true;
    }

    void TriggerUnpulled(object sender, ClickedEventArgs e)
    {
        if (holding == null) return;
        holding.transform.SetParent(oldParent);
        Rigidbody colRig = holding.GetComponent<Rigidbody>();
        colRig.isKinematic = false;
        holding.tag = "Draggable";
        colRig.velocity = SteamVR_Controller.Input((int)trackedController.controllerIndex).velocity;
        colRig.angularVelocity = SteamVR_Controller.Input((int)trackedController.controllerIndex).angularVelocity;
        holding = null;
    }
}
