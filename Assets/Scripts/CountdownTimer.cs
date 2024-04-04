using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 1200f;

    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        countdownText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            //print(currentTime);
            //countdownText.text = currentTime.ToString("0");

            if (currentTime <= 10)
            {
                countdownText.color = Color.red;
            }
        }
        else
        {
            currentTime = 0;
        }
        DisplayTime(currentTime);
    }

        void DisplayTime(float timeToDisplay)
        {
            if(timeToDisplay < 0)
            {
                timeToDisplay = 0;
                SceneManager.LoadScene("Game Over Scene");
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 * 1000;

            countdownText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds,miliseconds);
        }
    
}
