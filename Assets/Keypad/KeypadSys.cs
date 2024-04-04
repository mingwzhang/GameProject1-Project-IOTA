using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadSys : MonoBehaviour
{
    [SerializeField] public GameObject GamePanel;
    [SerializeField] private Text Ans;

    public TextNotify textNotify;

    //   public AudioSource audioData;

    public ObjectiveCheck obj;
    public GameObject keyPadTrigger;
    public GameObject pressE;
    public GameObject UnlockedWeapon;
    public GameObject[] AI = new GameObject[4];

    private string Answer = "1074";
    
    void Start()
    {
    //    GamePanel.SetActive(false);
    }

    private void Update()
    {
        
    }
    public void Number(int number)
    {
        Ans.text += number.ToString();
        FindObjectOfType<AudioManager>().Play("Keypad button");

    }

    [System.Obsolete]
    public void Activate()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "";
            //Play a correct audio cue
            FindObjectOfType<AudioManager>().Play("Keypad correct");

            obj.taskComplete();
            KeypadClose();
            Cursor.lockState = CursorLockMode.Locked;
            keyPadTrigger.active = false;
            pressE.active = false;
            textNotify.Success();
            textNotify.UnlockedWeapon();
            UnlockedWeapon.active = false;

            AI[0].SetActive(true);
            AI[1].SetActive(true);
            AI[2].SetActive(true);
            AI[3].SetActive(true);
            EmptyAIList();
}
        else
        {
            Ans.text = "";
            FindObjectOfType<AudioManager>().Play("ErrorBeep");
            Debug.Log("Error audio cue");

            textNotify.Failed();
        }
        
    }

    public void Clear()
    {
        Ans.text = "";
    }

    public void KeypadClose()
    {
        GamePanel.SetActive(false);
    }

    public void KeypadOpen()
    {
        GamePanel.SetActive(true);
    }

    public void EmptyAIList()
    {
        AI = new GameObject[0];
    }
}
