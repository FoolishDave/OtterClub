using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpeedIncrease : MonoBehaviour {

    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;
    public int baseCost;

    // Use this for initialization
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        if (PCGoldManager._pcGold < baseCost) return;
        PCGoldManager._pcGold -= baseCost;
        //Debug.Log(sp._maxSpawnedEnemies);
        EnemyHealth.speed += 0.5f;
        baseCost = (int)((double)baseCost * 1.5);
    }
}
