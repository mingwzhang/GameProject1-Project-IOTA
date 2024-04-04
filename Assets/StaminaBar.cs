using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the UI stamina bar for the player character.
/// </summary>
public class StaminaBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private float fillSpeed = 0.2f; // Speed at which the stamina bar fills
    [SerializeField] private PlayerMovement player; // Reference to the PlayerMovement script

    void Awake()
    {
        slider = gameObject.GetComponent<Slider>(); // Get the Slider component from the UI
    }

    void Update()
    {
        slider.value += fillSpeed * Time.deltaTime; // Fill the stamina bar over time
    }

    // Decreases the stamina bar value over time when sprinting.
    public void DecreaseStamina()
    {
        slider.value -= fillSpeed * 2 * Time.deltaTime; // Decrease stamina faster when sprinting
    }

    // Initiates sprinting for the player based on the stamina bar value.
    public void Sprint()
    {
        if (slider.value >= .1) // Check if there's enough stamina to sprint
        {
            player.Run(); // Call the Run method in the PlayerMovement script
        }
        else
        {
            player.StopRun(); // Call the StopRun method in the PlayerMovement script
        }
    }
}
