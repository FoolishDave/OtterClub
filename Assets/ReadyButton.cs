using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyButton : MonoBehaviour {

    public bool ready = false;
    public WaveSystem waveSys;

    public void OnPress()
    {
        ready = !ready;
        if (ready)
            GetComponent<Renderer>().material.color = Color.green;
        else
            GetComponent<Renderer>().material.color = Color.white;
        waveSys.VRConfirmReady(ready);
    }
}
