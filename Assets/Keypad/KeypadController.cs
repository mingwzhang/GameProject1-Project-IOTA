using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public KeypadSys Keypadsys;

    void OnMouseDown()
    {
        Keypadsys.KeypadClose();
    }
}
