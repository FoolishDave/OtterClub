﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health;
    public float baseDamage; 

    public Collider critical;
    public Collider normal;

    public SteamVR_TrackedController hitController;

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
