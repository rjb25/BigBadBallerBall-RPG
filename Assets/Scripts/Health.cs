using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    bool isDead;
    public int maxHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider; // Whether the player is dead.
   
    void Start()
    {
        currentHealth = maxHealth; 
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }
}
