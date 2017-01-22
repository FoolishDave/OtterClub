using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthIncrease : MonoBehaviour {

    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;
    public EnemyHealth eHealth;

    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {

        //Debug.Log(sp._maxSpawnedEnemies);
        Debug.Log(eHealth._health);
        eHealth._health=eHealth._health + 50;
        Debug.Log(eHealth._health);
    }

}
