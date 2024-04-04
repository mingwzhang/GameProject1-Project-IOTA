using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceRoom : MonoBehaviour
{
    public int nextBin;
    int[]sibArr;
    public GameObject gamePanel;
    public GameObject[] myObjects;

    public ObjectiveCheck obj; // From mingwei
    public Interactor interactor; //From mingwei
    public GameObject FurnacePanel; //From mingwei
    public GameObject pressE; //From mingwei
    public TextNotify textNotify; //From mingwei


    //public int[] myEmpty = new int[5];

    //int[] mybins;
    // Start is called before the first frame update
    void Start()
    {
        nextBin = 0;
        sibArr = new int[5];
        onEnable();
    }
    private void onEnable(){
        nextBin = 0; 
        for(int i = 0; i<myObjects.Length; i++){
            int ran = Random.Range(0,myObjects.Length);
            myObjects[i].transform.SetSiblingIndex(ran);
            
           // Debug.Log("<"+myObjects[i].name+">");
       }
       for(int a = 0; a<myObjects.Length; a++){
            //Debug.Log("sibindex <"+myObjects[i].transform.GetSiblingIndex()+">");
            sibArr[a] = myObjects[a].transform.GetSiblingIndex();
       }
      // Debug.Log(sibArr[0]+""+sibArr[1]+""+sibArr[2]+""+sibArr[3]+""+sibArr[4]);
    }

    [System.Obsolete]
    public void binOrder(string binNumber){
        //Debug.Log("Pressed "+ binNumber + " "+myObjects[sibArr[nextBin]].name);
        bool match = false; bool test = false;
        while (match == false)
        {
             for(int a = 0; a < myObjects.Length;a++){
                 //Debug.Log(" Input<"+ binNumber +" > ReqName< "+myObjects[sibArr[a]].name+ " >nextBin< "+nextBin+">sibArr[a]< "+sibArr[a] );
                 if(binNumber.Equals(myObjects[a].name) && nextBin == sibArr[a]){
                    nextBin++;
                    match = true;
                    test = true;
                    Debug.Log("<<<<next Bin " + nextBin);
                }
             }
             if(match == false){
                 match = true;
                 Debug.Log("<<<<Failed>>>>");
                textNotify.Failed();
             }

        }
        if(test == false){
            Debug.Log("<<<<Failed2>>>>");
            FindObjectOfType<AudioManager>().Play("badbeep");
            nextBin = 0;
            onEnable();
        }
        if(nextBin == 5 && test == true){
            FindObjectOfType<AudioManager>().Play("depressurize");
            Debug.Log("<<<<<<Passed>>>>>>>");
            textNotify.Success(); // From mingwei
            obj.taskComplete(); // From mingwei
            interactor.enabled = false; // From mingwei
            FurnacePanel.SetActive(false);  // From mingwei
            pressE.active = false;  // From mingwei


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

