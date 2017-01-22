using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public static float health;
    public float baseDamage; 

    public Collider critical;
    public Collider normal;

    public SteamVR_TrackedController hitController;

    public float _health
    {
        get { return _health; }
        set { _health = value; }
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
            Destroy(this.gameObject);
        }

    }
}
