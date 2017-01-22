using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {

    private int waveNumber;
    private bool VRReady;
    private bool PCReady;
    private int timer;

    void Start()
    {
        waveNumber = 0;
        timer = 100;
    }

    public void VRConfirmReady(bool ready)
    {
        VRReady = ready;
    }

    public void PCConfirmReady(bool ready)
    {
        PCReady = ready;
    }
}
