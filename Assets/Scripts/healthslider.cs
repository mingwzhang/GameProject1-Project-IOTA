using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthslider : MonoBehaviour
{  
    public Slider slider1;
    public Gradient gradient1;
    public Image fill1;

    public void SetMaxHealth(float health)
    {
        slider1.maxValue = health;
        slider1.value = health;

        fill1.color = gradient1.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider1.value = health;

        fill1.color = gradient1.Evaluate(slider1.normalizedValue);
    }
}
