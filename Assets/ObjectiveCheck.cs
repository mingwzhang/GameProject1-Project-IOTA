using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveCheck : MonoBehaviour
{

    private Slider slider;

    public float fillSpeed = 0.5f;
    private float count = 0;
    public TextNotify textNotify;
    public GameObject endgame;
    public GameObject arrowEnd;

    private int aiCount = 4;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if(slider.value < count)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }

        if(count == 4 && aiCount == 0)
        {
            endgame.SetActive(true);
            arrowEnd.SetActive(true);

            textNotify.AllFinished();
        }
    }

    public void loseAi()
    {
        aiCount--;
    }

    public void taskComplete()
    {
        count += 1;
    }
 
}
