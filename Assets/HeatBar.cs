using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour
{
    private Slider slider;
    private float fillSpeed = 0.2f;
    private float decreaseSpeed = 0.1f;

    // Start is called before the first frame update
    public HealthSystem hpSystem;
    private float takedmg = 0.2f;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void Update()
    {
        if (slider.value <= 0)
        {
            hpSystem.TakeDamage(takedmg);

        }
    }
    public void RegenerateHeatEndurance()
    {
        slider.value += fillSpeed * Time.deltaTime;
    }
    public void DecreaseHeatEndurance()
    {
        slider.value -= decreaseSpeed * Time.deltaTime;
    }
}
