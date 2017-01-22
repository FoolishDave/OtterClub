using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour {

    private int waveNumber;
    private bool VRReady;
    private bool PCReady;
    private float timer;
    private bool timing = false;
    public GameObject VrShop;
    public GameObject PcShop;
    public ReadyButton vrReadyButton;
    public GameObject PcWaveText;
    public ComputerScript PcScript;

    void Start()
    {
        waveNumber = 0;
        timer = 20f;
        DownTime();
    }

    public void VRConfirmReady(bool ready)
    {
        VRReady = ready;
        CheckStart();
    }

    public void PCConfirmReady(bool ready)
    {
        PCReady = ready;
        CheckStart();
    }

    void CheckStart()
    {
        if (PCReady && VRReady) BeginWave();
    }

    void BeginWave()
    {
        PcScript.spawningEnabled = true;
        PcWaveText.GetComponent<Text>().text = "Wave: " + waveNumber;
        VrShop.SetActive(false);
        PcShop.SetActive(false);
        timing = false;
    }

    public void DownTime()
    {
        PcScript.spawningEnabled = false;
        timer = 100;
        timing = true;
        PCReady = false;
        VRReady = false;
        waveNumber++;
        vrReadyButton.GetComponentInChildren<Text>().text = "Wave: " + waveNumber + "\nTime: " + timer;
        PcWaveText.GetComponent<Text>().text = "Wave: " + waveNumber + "\nTime left: " + timer;
        SpawnShop();
    }

    public float TimeLeft()
    {
        return timer;
    }

    void SpawnShop()
    {
        VrShop.SetActive(true);
        PcShop.SetActive(true);
    }

    void Update()
    {
        if (timing)
        {

            timer -= Time.deltaTime;
            vrReadyButton.GetComponentInChildren<Text>().text = "Wave: " + waveNumber + "\nTime: " + (int) timer;
            PcWaveText.GetComponent<Text>().text = "Wave: " + waveNumber + "\nTime left: " + (int) timer;
            //Debug.Log("Time left " + timer);
            if (timer<=0)
                BeginWave();
        }
    }
}
