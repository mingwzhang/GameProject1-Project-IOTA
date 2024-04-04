using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract =  null;
    public int ID = 0;
    public Sprite interactIcon = null;
    public Vector2 iconSize;
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0,99999);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
