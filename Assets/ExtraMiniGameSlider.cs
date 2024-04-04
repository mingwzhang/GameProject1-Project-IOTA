using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraMiniGameSlider : MonoBehaviour
{

    private Slider slider;

    public float current = .5f;

    private float Maxcount = 1;
    private float Mincount = 0;
    private float fillSpeed = 5;

    public ExtraMiniGame emg;
    public GameObject pressE;
    public ObjectiveCheck obj;
    public GameObject smoke;

    public GameObject sliderTrigger;

    public TextNotify textNotify;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        slider.value += current * fillSpeed * Time.deltaTime;

        if (slider.value >= Maxcount)
        {
            current--;
        }
        else if (slider.value <= Mincount)
        {
            current++;
        }
    }

    [System.Obsolete]
    public void Clicked()
    {
        if(.75 < slider.value && slider.value < .81)
        {
            emg.Close();


            Debug.Log("You win");
            FindObjectOfType<AudioManager>().Play("Keypad correct");

            textNotify.Success();

            Cursor.lockState = CursorLockMode.Locked;

            obj.taskComplete();
            pressE.active = false;
            smoke.active = false;
            sliderTrigger.active = false;
        }
        else
        {
            emg.Close();
            Cursor.lockState = CursorLockMode.Locked;
            slider.value = 1;

            textNotify.Failed();
            FindObjectOfType<AudioManager>().Play("UI Error");

            Debug.Log("You lose");
        }

    }
}
