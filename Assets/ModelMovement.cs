using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement : MonoBehaviour {

    public GameObject head;
    public GameObject body;

    void Update()
    {
        body.transform.position = new Vector3(transform.position.x, body.transform.position.y, transform.position.z);
        body.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, body.transform.rotation.w);
        //head.transform.localRotation = new Quaternion(0, 0, this.transform.rotation.z, 0);
        
       /* rightHand.transform.position = rightController.transform.position;
        rightHand.transform.rotation = rightController.transform.rotation;
        leftHand.transform.position = leftController.transform.position;
        leftHand.transform.rotation = leftController.transform.rotation;*/

    }
}
