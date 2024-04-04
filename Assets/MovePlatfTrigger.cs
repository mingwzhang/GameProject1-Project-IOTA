using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatfTrigger : MonoBehaviour
{

    public GameObject pt;
    public GameObject player;
    public float speed;
    private Vector3 upperFloor = new Vector3(0, 0, 0); //(-1, -5, 0)
    private Vector3 bottomFloor = new Vector3(0, -222, 0); //229, 0

    public LayerMask button;

    bool isTriggered;
    bool isAtTop = false;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, 50, button))
            {
                isTriggered = true;
                FindObjectOfType<AudioManager>().Play("Elevator click");
            }
        }

        if (isTriggered && !isAtTop)
        {
            MoveUp();
        }

        if (isTriggered && isAtTop)
        {
            //FindObjectOfType<AudioManager>().Play("doornoise");
            MoveDown();
        }

        if (pt.transform.position == upperFloor)
        {
            isTriggered = false;
            isAtTop = true;
        }
        if (pt.transform.position == bottomFloor)
        {
            isTriggered = false;
            isAtTop = false;
        }
    }

    private void MoveUp()
    {
        pt.transform.position = Vector3.MoveTowards(pt.transform.position, upperFloor, speed * Time.deltaTime);
        
    }
    private void MoveDown()
    {
        pt.transform.position = Vector3.MoveTowards(pt.transform.position, bottomFloor, speed * Time.deltaTime);
    }
 
}