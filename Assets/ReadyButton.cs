using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyButton : MonoBehaviour {

    public bool ready = false;
    public WaveSystem waveSys;

    public void OnPress()
    {
        ready = !ready;
        waveSys.VRConfirmReady(ready);
    }
}
