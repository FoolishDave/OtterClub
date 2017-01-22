using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour {

    private int waveNumber;
    private bool VRReady;
    private bool PCReady;
    private float downTimer;
    private bool downTiming = false;
    public GameObject VrShop;
    public GameObject PcShop;
    public ReadyButton vrReadyButton;
    public GameObject PcWaveText;
    public ComputerScript PcScript;
    public SpawnScript spawnScript;
    public PCGoldManager pcGold;

    void Start()
    {
        waveNumber = 0;
        downTimer = 20f;
        PCGoldManager._baseGold = 20;
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
        pcGold.preWave();
        PcScript.spawningEnabled = true;
        PcWaveText.GetComponent<Text>().text = "Wave: " + waveNumber;
        VrShop.SetActive(false);
        PcShop.SetActive(false);
        downTiming = false;
        PCReady = false;
        VRReady = false;
    }

    public void DownTime()
    {
        
        PcScript.spawningEnabled = false;
        downTimer = 5;
        downTiming = true;
        PCReady = false;
        VRReady = false;
        waveNumber++;
        vrReadyButton.GetComponentInChildren<Text>().text = "Wave: " + waveNumber + "\nTime: " + downTimer;
        PcWaveText.GetComponent<Text>().text = "Wave: " + waveNumber + "\nTime left: " + downTimer;
        SpawnShop();
    }

    public float TimeLeft()
    {
        return downTimer;
    }

    void SpawnShop()
    {
        VrShop.SetActive(true);
        PcShop.SetActive(true);
    }

    void Update()
    {
        if (downTiming)
        {

            downTimer -= Time.deltaTime;
            vrReadyButton.GetComponentInChildren<Text>().text = "Wave: " + waveNumber + "\nTime: " + (int) downTimer;
            PcWaveText.GetComponent<Text>().text = "Wave: " + waveNumber + "\nTime left: " + (int) downTimer;
            //Debug.Log("Time left " + timer);
            if (downTimer<=0)
                BeginWave();
        } else
        {
            if (spawnScript._totalEnemiesSpawned == spawnScript.maxSpawnedEnemies)
            {
                if (GameObject.FindGameObjectsWithTag("Unity~Chan<3").Length==0)
                {
                    spawnScript.resetGame();
                    DownTime();
                }
            }
        }
    }
}
