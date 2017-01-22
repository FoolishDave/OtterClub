﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpeedIncrease : MonoBehaviour {

    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;
    public EnemyHealth eHealth;
    public int baseCost;

    // Use this for initialization
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        baseCost = 300;
    }


    void TaskOnClick()
    {

        //Debug.Log(sp._maxSpawnedEnemies);
        EnemyHealth.speed += 2;
        baseCost = (int)((double)baseCost * 1.5);
    }
}
