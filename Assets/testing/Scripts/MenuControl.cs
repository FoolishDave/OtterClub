using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Toggles the menu when escape is pressed
/// </summary>
public class MenuControl : MonoBehaviour {

    /// <summary>
    /// The menu to toggle
    /// </summary>
    public GameObject menu;
	
	/// <summary>
    /// Checks if the escape key has been pressed to enable/disable the menu
    /// </summary>
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
	}
}
