using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour {

    public List<GameObject> weapons = new List<GameObject>();
    public int currentWeapon = 0;
    GameObject curWep;

    SteamVR_TrackedController trackedController;

	// Use this for initialization
	void Start () {
        trackedController = GetComponent<SteamVR_TrackedController>();
        trackedController.PadClicked += new ClickedEventHandler(PadClick);
        curWep = weapons[0];
	}
	
    void PadClick(object sender, ClickedEventArgs e)
    {
        if (e.padX > 0)
            currentWeapon++;
        if (e.padX < 0)
            currentWeapon--;
        if (currentWeapon >= weapons.Count)
            currentWeapon = 0;
        if (currentWeapon < 0)
            currentWeapon = weapons.Count - 1;
        curWep.SetActive(false);
        weapons[currentWeapon].SetActive(true);
        curWep = weapons[currentWeapon];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
