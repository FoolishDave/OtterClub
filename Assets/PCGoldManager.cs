using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGoldManager : MonoBehaviour {

    //total gold to use at the end of each round
    public static int _pcGold;
    //Basegold to add after every round
    public static int _baseGold;
    //base gold multiplier
    public static double _multiplier;

    public int goldToUse
    {
        get { return _pcGold; }
        set { _pcGold = value; }
    }
    public int baseGold
    {
        get { return _baseGold; }
        set { _baseGold = value; }
    }
    public double multiplier
    {
        get { return _multiplier; }
        set { _multiplier = value; }
    }
	// Use this for initialization
	void Start () {
        _pcGold = 0;
	}
	

    /**<summary>
    Give alloted cash to spend on unit upgrades
    </summary>**/
    public void preWave ()
    {
        _pcGold += baseGold;
        _baseGold = (int)((double)_baseGold*_multiplier);
    }
}
