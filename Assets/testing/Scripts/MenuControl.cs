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

<<<<<<< HEAD


    /// <summary>
    /// On launch ensure the menu is set to inactive
    /// </summary>
	void Start()
=======
    private void Start()
>>>>>>> refs/remotes/origin/master
    {
        ComputerScript.menuActive = false;
        menu.SetActive(false);
    }

    /// Checks if the escape key has been pressed to enable/disable the menu
    /// </summary>
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool newState = !menu.activeSelf;
            ComputerScript.menuActive = newState;
            menu.SetActive(newState);
        }
	}
}
