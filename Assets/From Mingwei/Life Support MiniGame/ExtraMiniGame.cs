using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraMiniGame : MonoBehaviour
{

    public ExtraMiniGameSlider slider;
    public GameObject GamePanel;

    private void Update()
    {
        
    }

    [System.Obsolete]
    public void Click()
    {
        slider.Clicked();
        FindObjectOfType<AudioManager>().Stop("gun equipped");
        FindObjectOfType<AudioManager>().Stop("Laser Gun 2");
    }

    public void Close()
    {
        GamePanel.SetActive(false);
    }

    public void Open()
    {
        GamePanel.SetActive(true);
        FindObjectOfType<AudioManager>().Play("beepboop");
        FindObjectOfType<AudioManager>().Stop("gun equipped");
        FindObjectOfType<AudioManager>().Stop("Laser Gun 2");
    }

}
