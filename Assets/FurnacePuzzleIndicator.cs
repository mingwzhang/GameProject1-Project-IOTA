using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnacePuzzleIndicator : MonoBehaviour
{
    public GameObject player;
    public GameObject FurnacePanel;
    public HeatBar heatbar;
    public GameObject heatbarIndic;


    private bool trigger;

    // Update is called once per frame
    void Update()
    {
        if(trigger == true)
        {
            FurnacePanel.SetActive(true);
            heatbar.DecreaseHeatEndurance();
        }
        else
        {
            FurnacePanel.SetActive(false);
            heatbar.RegenerateHeatEndurance();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            trigger = false;
        }
    }
}
