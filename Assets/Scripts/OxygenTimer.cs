using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTimer : MonoBehaviour
{
    public Slider oSLider;
    public float oTimer;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        oSLider.maxValue = oTimer;
        oSLider.value = oTimer;
    }

    // Update is called once per frame
    void Update()
    {
        time = oTimer - Time.time;
        oSLider.value = time;

        if(time <= 0)
        {
            //create lose condition
        }
    }
    public void binInteract(){
        oTimer = oTimer + 10f;
        //Debug.Log("binInteract");
    }
}
