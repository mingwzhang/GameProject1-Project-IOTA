using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script manages the player's health system, including taking damage, low health indication, and game over conditions.
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 1000f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float damage;
    [SerializeField] private healthslider HealthSlider; // Reference to the HealthSlider UI component

    private bool enemyHit = false;
    [SerializeField] private float enemyDamage;

    [SerializeField] private GameObject hub;
    [SerializeField] private GameObject hub_dmged;
    private bool isHubDmged = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthSlider.SetMaxHealth(maxHealth); // Initialize the HealthSlider with the maximum health
    }

    void Update()
    {
        lowHpIndication(); // Check for low health indication
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        if (enemyHit == true)
        {
            EnemyHit(); // Handle damage from enemy hits
        }

        if (currentHealth <= 0)
        {
            GameOver(); // Trigger game over if health reaches zero
        }
    }

    // Display low health indication based on current health
    private void lowHpIndication()
    {
        if (currentHealth <= maxHealth / 3)
        {
            hub_dmged.SetActive(true); // Activate damaged hub UI
            hub.SetActive(false); // Deactivate normal hub UI
            isHubDmged = true;
        }
        else
        {
            if (isHubDmged == true && currentHealth >= maxHealth / 3)
            {
                hub.SetActive(true); // Activate normal hub UI
                hub_dmged.SetActive(false); // Deactivate damaged hub UI
                isHubDmged = false;
            }
        }
    }

    // Method to handle taking damage from various sources
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthSlider.SetHealth(currentHealth); // Update the health UI
    }

    // Method to handle damage from enemy hits
    public void EnemyHit()
    {
        currentHealth -= enemyDamage;
        HealthSlider.SetHealth(currentHealth); // Update the health UI
    }

    // Method to handle game over conditions
    private void GameOver()
    {
        FindObjectOfType<AudioManager>().Stop("Laser Gun 2"); // Stop specific audio
        Cursor.lockState = CursorLockMode.None; // Set cursor to unlocked state
        SceneManager.LoadScene("Game Over Scene"); // Load the game over scene
    }

    // Detect when the player collides with an enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyHit = true; // Set enemyHit flag to true
        }
    }

    // Detect when the player exits collision with an enemy
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyHit = false; // Set enemyHit flag to false
        }
    }
}
