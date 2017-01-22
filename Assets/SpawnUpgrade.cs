using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUpgrade : MonoBehaviour {
    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;
    public SpawnScript spawner;
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
        baseCost = (int)((double)baseCost * 1.5);
        Debug.Log(spawner.maxSpawnedEnemies);
        spawner.maxSpawnedEnemies = spawner.maxSpawnedEnemies+1;
        Debug.Log(spawner.maxSpawnedEnemies);
    }
}
