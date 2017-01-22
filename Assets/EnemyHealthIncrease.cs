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
        baseCost = 300;
    }


    void TaskOnClick()
    {

        //Debug.Log(sp._maxSpawnedEnemies);
        Debug.Log(eHealth._health);
        eHealth._health=eHealth._health + 50;
        Debug.Log(eHealth._health);
        baseCost = (int)((double)baseCost * 1.5);
    }

}