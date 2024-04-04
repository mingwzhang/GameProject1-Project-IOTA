using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shields : MonoBehaviour
{
   [SerializeField] GameObject[] arrButtons;
   [SerializeField] int[] intButtons;
   [SerializeField] bool Failed = true;
   [SerializeField] GameObject gamePanel;
   [SerializeField] GameObject gameCanvas;
   [SerializeField] GameObject taskCompleted;
    [SerializeField] ObjectiveCheck obj;         //from mingwei
    [SerializeField] GameObject LSTrigger;         //from mingwei
    public TextNotify textNotify;  // from mingwei
    public GameObject indictE;

    Color32 red = new Color32(255, 39, 0, 255);
   Color32 white = new Color32(255,255,255,255);

   void Update()//used to exit the game at anytime
    {
       // if (Input.GetKeyDown(KeyCode.E))
       // {
            //Cursor.lockState = CursorLockMode.Locked;
            //ClosePanel();
            //DiableInteractableButtons();
         //   gameCanvas.SetActive(false);
         //   Cursor.visible = false;
     //   }

    }
   public void OnCall(){ //initilaizes game UI and starts game
       
  //     Cursor.lockState = CursorLockMode.None;
  //     Cursor.visible = true;
       EnableInteractableButtons();

       for(int i = 0; i < arrButtons.Length; i++){
           intButtons[i] = Random.Range(0,2);
       }
       for(int i = 0; i < arrButtons.Length;i++){

           if( intButtons[i]==0){
               arrButtons[i].GetComponent<Image>().color = white;
               //arrButtons[i].transform.GetChild(0).GetComponent<Image>().color = white;
           }
           if( intButtons[i]==1){
               arrButtons[i].GetComponent<Image>().color = red;
               //arrButtons[i].transform.GetChild(0).GetComponent<Image>().color = red;
           }
       }
   }
   public void ButtonsClicked(int button){ //reference method for when a button is clicked
       Debug.Log("Button Clicked");
       
       if(arrButtons[button].GetComponent<Image>().color == red){
           arrButtons[button].GetComponent<Image>().color = white;
           FindObjectOfType<AudioManager>().Play("beepboop");
           //arrButtons[button].transform.GetChild(0).GetComponent<Image>().color = white;
       }
       else{
           arrButtons[button].GetComponent<Image>().color = red;
           FindObjectOfType<AudioManager>().Play("badbeep");
           //arrButtons[button].transform.GetChild(0).GetComponent<Image>().color = red;
       }
       CheckButtons();
   }
   
   public void CheckButtons(){ //check for win condition
       Failed = false;
       for(int i = 0; i < arrButtons.Length;i++){
           if(arrButtons[i].GetComponent<Image>().color == red){
               Failed = true;
               break;
           }
       }
       if(Failed == false){
           //DiableInteractableButtons();
           Debug.Log("Task Completed");
           FindObjectOfType<AudioManager>().Play("successbeep");
           Cursor.lockState = CursorLockMode.Locked;
           //Cursor.visible = false;         //from mingwei
            ClosePanel();


           LSTrigger.SetActive(false);   //from mingwei
           obj.taskComplete();          //from mingwei
            textNotify.Success(); //from mingwei
            indictE.SetActive(false);
        }
   }
   
   public void CloseCanvas()  //from mingwei
    {
        gameCanvas.SetActive(false);
    }

    public void OpenCanvas()  //from mingwei
    {
        gameCanvas.SetActive(true);
    }
    public void ClosePanel(){
       gamePanel.SetActive(false);
       
    }
    public void OpenPanel(){
        gamePanel.SetActive(true);
    }
    private void DiableInteractableButtons(){
        for(int i = 0; i < arrButtons.Length; i++){
            arrButtons[i].GetComponent<Button>().interactable = false;
        }
    }
    private void EnableInteractableButtons(){
        for(int i = 0; i < arrButtons.Length; i++){
            arrButtons[i].GetComponent<Button>().interactable = true;
        }
    }
}
