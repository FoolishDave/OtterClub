using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUpgrade : MonoBehaviour {
    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;
    public GameObject Master;
    public SpawnScript spawner;
    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    
    void TaskOnClick()
    {

        //Debug.Log(sp._maxSpawnedEnemies);
        Debug.Log(spawner.maxSpawnedEnemies);
        spawner.maxSpawnedEnemies = spawner.maxSpawnedEnemies+1;
        Debug.Log(spawner.maxSpawnedEnemies);
    }
}
