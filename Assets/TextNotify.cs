using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNotify : MonoBehaviour
{
    public GameObject taskfailedText;
    public GameObject taskSuccessText;
    public GameObject taskAllFinishedText;
    public GameObject unlockedWeaponText;
    public GameObject warningText;


    void Start()
    {

    }

    void Update()
    {

    }

    public void Failed()
    {
        taskfailedText.SetActive(true);

        StartCoroutine(failedDisappear());
    }
    public void Success()
    {
        taskSuccessText.SetActive(true);

        StartCoroutine(successDisappear());
    }

    public void UnlockedWeapon()
    {
        unlockedWeaponText.SetActive(true);

        StartCoroutine(unlockedWeaponDisappear());
    }

    public void warning()
    {
        warningText.SetActive(true);
        StartCoroutine(warningTextDisappear());

    }
    public void AllFinished()
    {
        taskAllFinishedText.SetActive(true);
    }


    IEnumerator failedDisappear()
    {
        yield return new WaitForSeconds(3);

        taskfailedText.SetActive(false);        

    }

    IEnumerator successDisappear()
    {
        yield return new WaitForSeconds(3);

        taskSuccessText.SetActive(false);
    }

    IEnumerator unlockedWeaponDisappear()
    {
        yield return new WaitForSeconds(5);

        unlockedWeaponText.SetActive(false);
    }

    IEnumerator warningTextDisappear()
    {
        yield return new WaitForSeconds(3);

        warningText.SetActive(false);
    }

}
