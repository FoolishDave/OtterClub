using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour {

    public Button yourButton;
	// Use this for initialization
	void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void TaskOnClick () {
        Application.LoadLevel("ComputerTest ui");
	}
}
