using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public static float maxHealth = 100;
    public static float enemyDamage = 20;
    public static float speed = 7.5f;

    public float health;
    public float baseDamage;

    public Collider critical;
    public Collider normal;

    public SteamVR_TrackedController hitController;

    public float _health
    {
        get { return health; }
        set { health = value; }
    }
    public float _baseDamage
    {
        get { return baseDamage; }
        set { baseDamage = value; }
    }

    public float _speed
    {
        get { return speed; }
        set { speed = value; }
    }

	void OnTriggerEnter(Collider col)
    {
        float damageMult = 1f;
        if (col.tag.Equals("Weapon"))
        {
            hitController = col.GetComponent<SteamVR_TrackedController>();
            if (hitController == null)
                hitController = col.GetComponentInParent<SteamVR_TrackedController>();
            if (col == critical)
                damageMult = 2.5f;
            float velocity = SteamVR_Controller.Input((int)hitController.controllerIndex).velocity.sqrMagnitude;
            if (velocity < 10)
                damageMult *= velocity / 10;
            else if (velocity > 20)
                damageMult *= velocity / 10;
            ApplyDamage(baseDamage * damageMult);
        }
    }

    void ApplyDamage(float damage)
    {
        health -= damage;
        Vector3 controllerVelocity = SteamVR_Controller.Input((int)hitController.controllerIndex).velocity;
        GetComponent<Rigidbody>().AddForce(controllerVelocity*10f);
        if (health <= 0f)
        {
            VrGoldManager.playerKilledEnemy(speed, enemyDamage, maxHealth);
            this.gameObject.SetActive(false);
            SpawnScript.spawnScript.killEnemy(this.gameObject);
        }

    }
}
