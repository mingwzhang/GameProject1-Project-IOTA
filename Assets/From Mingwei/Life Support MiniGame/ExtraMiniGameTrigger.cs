using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtraMiniGameTrigger : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;
    public ExtraMiniGame emg;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, rayLength, layermask))
            {
                if (emg.GamePanel.activeInHierarchy == false)
                {
                    Cursor.lockState = CursorLockMode.None;
                    emg.Open();
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    emg.Close();
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                emg.Close();
            }
        }
    }
}