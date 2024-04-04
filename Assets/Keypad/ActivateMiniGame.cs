using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateMiniGame : MonoBehaviour
{
    public float rayLength;
    public LayerMask[] layermask = new LayerMask[2];

    public KeypadSys Keypadsys;
    public ExtraMiniGame emg;
    public Shields shields;

    //Functions as read, meant to set Base and its children inactive on Start. Manually enabled/disabled by Update and KeypadTriggerClose.

    //Differs from DataPadScript methodology of calling the toggle and manual exit in update. This is the first iteration, would rather not mess with it for now. 
    //Primary access/exit toggle for the Base object. Cursor must be inside box collider of KeypadTrigger to enable accessibility. Can toggle through the keypad popup by pressing Q again. Manual exit is E keybind. 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.SphereCast(ray, 0.5f, rayLength, layermask[0]))
            {
                if (Keypadsys.GamePanel.activeInHierarchy == false)
                {
                    Keypadsys.KeypadOpen();
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Keypadsys.KeypadClose();
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            else if (Physics.SphereCast(ray, 0.5f, rayLength, layermask[1]))
            {
                if (emg.GamePanel.activeInHierarchy == false)
                {
                    emg.Open();
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    emg.Close();
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }else if (Physics.SphereCast(ray, 0.5f, rayLength, layermask[2]))
            {
                if (shields.gameObject.activeInHierarchy == false)
                {
                    shields.OpenCanvas();
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    shields.CloseCanvas();
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Keypadsys.KeypadClose();
                emg.Close();
                shields.CloseCanvas();
            }
        }
    }
    }
    //CursorFree();
    //       KeypadTriggerClose();


    //Keybound manual exit from accessing the UI_Canvas1>Keypad>Canvas>Base object. 
    //public void KeypadTriggerClose()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q) && !EventSystem.current.IsPointerOverGameObject())
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out hit, rayLength, layermask))
    //        {
    //            if (Keypadsys.GamePanel.activeInHierarchy == true)
    //            {
    //                Keypadsys.KeypadClose();
    //            }
    //        }
    //    }
    //}

    //Frees the cursor to use keypad buttons.
    //public void CursorFree()
    //{
    //if (Keypadsys.GamePanel.activeInHierarchy == true)
    //{
    //Cursor.lockState = CursorLockMode.None;
    //}
    //else
    //{
    //Cursor.lockState = CursorLockMode.Locked;
    //}
    //}

