using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1_Animation : MonoBehaviour
{    
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enter trigger");
            
            myDoor.Play("door_1_open", 0, 0.0f);

            FindObjectOfType<AudioManager>().Play("doornoise");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exit trigger");

            myDoor.Play("door_1_close", 0, 0.0f);

            FindObjectOfType<AudioManager>().Play("doornoise");
        }
    }
}

