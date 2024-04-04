using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    public Transform equipPosition;
    public float distance = 10f;
    GameObject currentItem;
    GameObject wearposition;
    public DataPadScript EmptyAIList;
    bool canGrab;

    public gun gotGun;

    private void Update()
    {
        CheckItem();
        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentItem != null)
                    Drop();
                PickUp();
            }
        }

        if (currentItem != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Drop();
                FindObjectOfType<AudioManager>().Stop("Laser Gun 2");

            }
        }
    }

    private void CheckItem()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Gun")
            {
                canGrab = true;
                wearposition = hit.transform.gameObject;
            }
        }
        else
            canGrab = false;
    }

    private void PickUp()
    {
        gotGun.WeaponOnHand();
        currentItem = wearposition;
        currentItem.transform.position = equipPosition.position;
        currentItem.transform.parent = equipPosition;
        currentItem.transform.localEulerAngles = new Vector3(-85f, 90f, -190);
        currentItem.GetComponent<Rigidbody>().isKinematic = true;


    }

    private void Drop()
    {
        gotGun.offHand();
        FindObjectOfType<AudioManager>().Stop("gun equipped");
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem = null;
    }


}