using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamageIncrease : MonoBehaviour {

    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;
    public EnemyHealth eDamage;
    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        
        Debug.Log(eDamage._baseDamage);
        eDamage._baseDamage = eDamage._baseDamage + 20;
        Debug.Log(eDamage._baseDamage);
    }
}
