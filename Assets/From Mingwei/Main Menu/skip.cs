using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{

    public GameObject Canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Destroy(GameObject.Find("Video Player"));
            Canvas.SetActive(true);
        }
    }
}
