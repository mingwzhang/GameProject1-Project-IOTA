// DO NOT MOVE THIS FILE. IT DOES NOT LIKE BEING MOVED TO SCRIPTS AND I DON'T KNOW WHY.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 1000f;
    public float currentHealth;
    public float damage;
    public healthslider HealthSlider;

    private bool enemyHit = false;
    public float enemyDamage;

    public GameObject hub;
    public GameObject hub_dmged;
    private bool isHubDmged = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthSlider.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        lowHpIndication();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyHit == true)
        {
            EnemyHit();
        }

        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    void lowHpIndication()
    {
        if (currentHealth <= maxHealth / 3)
        {
            hub_dmged.SetActive(true);
            hub.SetActive(false);
            isHubDmged = true;
        }
        else
        {
            if (isHubDmged == true && currentHealth >= maxHealth / 3)
            {
                hub.SetActive(true);
                hub_dmged.SetActive(false);
                isHubDmged = false;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthSlider.SetHealth(currentHealth);        
    }

    public void EnemyHit()
    {
        currentHealth -= enemyDamage;
        HealthSlider.SetHealth(currentHealth);
    }

    private void GameOver()
    {
        FindObjectOfType<AudioManager>().Stop("Laser Gun 2");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Game Over Scene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyHit = false;
        }
    }



}
