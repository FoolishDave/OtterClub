using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour {

    public RectTransform hBar;
    public Canvas canvas;
    public PlayerHealth pHealth;

    private float barMax;
    private float healthPercent;
    private float barHeight;


	// Use this for initialization
	void Start () {
        barMax = 300;
        healthPercent = 1;
        barHeight = 15;
        hBar.sizeDelta = new Vector2(barMax, barHeight);
    }
	
	// Update is called once per frame
	void Update () {
        healthPercent = (float)(pHealth.health / pHealth.maxHealth);
        hBar.sizeDelta = new Vector2(barMax * healthPercent, barHeight);

    }
}
