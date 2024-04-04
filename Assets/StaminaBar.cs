using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    private Slider slider;
    public float fillSpeed = 0.2f;

    public PlayerMovement player;


    private bool isRunning;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        slider.value += fillSpeed * Time.deltaTime;
    }

    public void DecreaseStamina()
    {
        slider.value -= fillSpeed * 2 * Time.deltaTime;
    }
    public void Sprint()
    {
        if (slider.value >= .1)
        {
            player.Run();
        }
        else
        {
            player.StopRun();
        }
    }
}
