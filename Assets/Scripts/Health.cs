﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//This class controls health and death. Pretty straight forward.
public class Health : MonoBehaviour
{


    bool isDead;
    public int maxHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;
    public Transform healthBox;// The current health the player has.
    public Slider healthSlider; // Whether the player is dead.
    private float scaleMax = 1;
    public bool noBreak = false;
    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        if (healthBox)
        {
            scaleMax = healthBox.localScale.x;
        }
    }
    public static void Damage(GameObject to, int amount)
    {

        DamageTransfer ds = to.GetComponent<DamageTransfer>();
        Health hs = to.GetComponent<Health>();
        if (ds)
        {
            ds.Transfer(amount);
        }else
        if (hs)
        {
            hs.TakeDamage(amount);
        }
     
        else
        {
            print("object is tagged but has no damage handler" + to.name);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

            // Set the health bar's value to the current health.
            if (healthSlider)
            {
                healthSlider.value = currentHealth;
            }
            if(healthBox)
            {
                float percentLost = amount / (maxHealth + 0.001f);
                healthBox.localScale -= new Vector3(percentLost*scaleMax , 0f, 0f);
            }

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
        {
            isDead = true;

            //could call directly for better performance, but send message allows the most flexibility for now.
            //this will call all functions named OnDeath on this object and its children.

            BroadcastMessage("OnDeath");

            gameObject.SetActive(false);
            if (!noBreak)
            {
                Invoke("DestroyGameObject", 2);
                
            }
        }
    }
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
