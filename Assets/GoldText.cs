using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoldText : MonoBehaviour {

    private Text gold;
    public PCGoldManager Master;
 	// Use this for initialization
	void Start () {
        gold = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        gold.text = "Gold :" + Master.goldToUse;
	}
}
