﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthIncrease : MonoBehaviour {

    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;
    public EnemyHealth eHealth;
    public int baseCost;

    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        if (PCGoldManager._pcGold < baseCost) return;
        PCGoldManager._pcGold -= baseCost;
        //Debug.Log(sp._maxSpawnedEnemies);
        EnemyHealth.maxHealth += 50;
        baseCost = (int)((double)baseCost * 1.5);
    }

}
