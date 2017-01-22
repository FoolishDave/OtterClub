using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrGoldManager : MonoBehaviour {

    public static int cash = 0;
    public int baseCashPerKill = 2;
    static int cashPerKill;

    void Start()
    {
        cashPerKill = baseCashPerKill;
    }

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
        giveMoney(cashPerKill + (int)(speed / 7f) - 1 + (int)(damage / 20) - 1 + (int)(health / 100) - 1);
    }
}
