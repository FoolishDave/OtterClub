using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCReadyButton : MonoBehaviour {

    private bool ready = false;
    public WaveSystem waveSys;
    public Color readyColor;
    public Color readyHighlightColor;
    public Color readyPressedColor;
    private Color oldColor;
    private Color oldHighlightColor;
    private Color oldPressedColor;
    private ColorBlock readyBlock;
    void Start()
    {
        readyBlock = ColorBlock.defaultColorBlock;
        readyBlock.normalColor = readyColor;
        readyBlock.highlightedColor = readyHighlightColor;
        readyBlock.pressedColor = readyPressedColor;
    }

	public void setReady()
    {
        ready = !ready;
        waveSys.PCConfirmReady(ready);
        Button button = GetComponent<Button>();
        if (ready)
        {
            button.colors = readyBlock;
        } else
        {
            button.colors = ColorBlock.defaultColorBlock;
        }
    }
}
