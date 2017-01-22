using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth playerHealth;
    
    public float health;
    public float maxHealth;

    private void Awake()
    {
        playerHealth = this;
        health = maxHealth;
    }
}
