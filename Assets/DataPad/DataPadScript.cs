using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataPadScript : MonoBehaviour
{
    public GameObject[] Datapadarr = new GameObject[6];

    public float rayLength;
    public LayerMask layermask;
    public string currentObjectHit;
    public int inttag;
    
    public int actOnce = 1;
    public GameObject[] AI = new GameObject[2];
    public TextNotify TextNotify;
    //Functions as read, meant to set DataPad_CloseUp and its children inactive on Start.
    void Start()
    {
        for (int i = 0; i < Datapadarr.Length; i++)
        {
            Datapadarr[i].SetActive(false);
        }
    }

    //Frame to frame detection of KeyCodes/Cursor position.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.SphereCast(ray, 0.5f, out hit, rayLength, layermask))
            {
                currentObjectHit = hit.transform.tag;
                inttag = int.Parse(currentObjectHit);

                if (Datapadarr[inttag].activeInHierarchy == false)
                {
                    FindObjectOfType<AudioManager>().Stop("gun equipped");
                    FindObjectOfType<AudioManager>().Stop("Laser Gun 2");
                    DatapadOpen();
                    FindObjectOfType<AudioManager>().Play("beepboop");

                    //                   Debug.Log("Datapad Active: " + Datapadarr[inttag]);
                }
                else
                {
                    DatapadClose();
 //                   Debug.Log("Datapad Inactive 1: " + Datapadarr[inttag]);
                }
            }else
            {
                DatapadClose();
//                Debug.Log("Datapad Inactive 2: " + Datapadarr[inttag]);
            }
        }
    }

     public void DatapadClose()
    {
        Datapadarr[inttag].SetActive(false);
    }

    public void DatapadOpen()
    {
        Datapadarr[inttag].SetActive(true);
        NoMoreAI();
        actOnce--;
    }


    void NoMoreAI()
    {
        if (actOnce < 1)
        {
            AI = new GameObject[0];
        }
        else
        {
            TextNotify.warning();
            AI[0].SetActive(true);
            AI[1].SetActive(true);
         }
    }
}
