using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashChecker : MonoBehaviour {
    Text moneyText;
	// Use this for initialization
	void Start () {
        moneyText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "Money: " + VrGoldManager.cash;
	}
}
