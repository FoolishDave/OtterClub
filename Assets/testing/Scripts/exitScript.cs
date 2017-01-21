using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to exit game on button press
/// </summary>
public class exitScript : MonoBehaviour {

    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;

    /// <summary>
    /// Gets the button and adds a listener to it
    /// </summary>
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    /// <summary>
    /// Exits application on click
    /// </summary>
    void TaskOnClick()
    {
        Debug.Log("Exit application");
        Application.Quit();
    }
}
