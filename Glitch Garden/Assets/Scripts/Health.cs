using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    private float maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        float mathHP = health / maxHealth;
        healthBar.SetSize(mathHP);
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
