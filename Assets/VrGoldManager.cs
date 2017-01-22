using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrGoldManager : MonoBehaviour {

    public static int cash = 0;

    public static void giveMoney(int amt)
    {
        cash += amt;
    }

    public static void takeMoney(int amt)
    {
        cash -= amt;
    }

    public static bool hasMoney(int amt)
    {
        return cash >= amt;
    }

    public static void playerKilledEnemy(float speed, float damage, float health)
    {

    }
}
